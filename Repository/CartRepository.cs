using Beadando.Data;
using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Repository
{
    internal class CartRepository
    {
        private Context context;

        public CartRepository(Context context)
        {
            this.context = context;
        }

        public List<Cart> GetAll()
        {
            return context.Cart.Include(us => us.User).Include(pro => pro.Product).ToList();
        }

        public List<Cart> GetByUserId(int userId)
        {
            return context.Cart.Where(p => p.UserId == userId).Include(us => us.User).Include(pro => pro.Product).ToList();
        }

        private int GetCartIdByUidAndProductId(int uid, int productId)
        {
            return context.Cart.Where(p => p.UserId == uid && p.ProductId == productId)
                .ToList().First().Id;
        }

        public int GetPriceSum(int userId)
        {
            return GetByUserId(userId).Sum(p => p.Product.Price * p.Counts);
        }

        // Megnézi, hogy van-e elmentve
        private bool IsExist(int userId, int productId) 
        {
            bool result = false;

            if (context.Cart.Where(p => p.UserId == userId && p.ProductId == productId)
                .ToList().Count > 0)
            {
                result = true;
            }

            return result;
        }

        public void AddItemToCart(int userId, int productId, int count)
        {
            // Ha van már ugyanilyen termék és felhasználó elmentve, akkor
            // kikeresi és updateli a darabszámot

            if (!IsExist(userId, productId))
            {
                context.Cart.Add(new Cart
                {
                    UserId = userId,
                    ProductId = productId,
                    Counts = count
                });
            }
            else
            {
                UpdateCartItem(GetCartIdByUidAndProductId(userId, productId));
            }
        }

        private void UpdateCartItem(int cartId)
        {
            context.Cart.Find(cartId).Counts += 1;
        }

        public void DeleteItemFromCart(int cartId)
        {
            context.Cart.Remove(context.Cart.Find(cartId));
        }

        public void ClearCartItems(int userId)
        {
            List<Cart> items = GetByUserId(userId);
            foreach (Cart item in items)
            {
                context.Cart.Remove(item);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

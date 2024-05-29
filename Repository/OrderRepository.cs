using Beadando.Data;
using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Beadando.Repository
{
    class OrderRepository
    {
        private Context context;

        public OrderRepository(Context context)
        {
            this.context = context;
        }

        public List<Order> GetAll()
        {
            return context.Order.ToList();
        }

        public List<Order> GetOrderByUid(int uid)
        {
            return context.Order.Where(p => p.Uid == uid).Include(us => us.User).ToList();
        }

        public void AddOrder(Order order)
        {
            context.Order.Add(order);
        }


        public void Save()
        {
            context.SaveChanges();
        }
    }
}

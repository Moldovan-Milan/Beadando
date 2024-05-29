using Beadando.Data;
using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Beadando.Repository
{
    internal class ProductRepository
    {
        private Context context;

        public ProductRepository(Context context)
        {
            this.context = context;
        }

        public List<Product> GetProducts()
        {
            return context.Products.Include(img => img.Img).Include(cat => cat.Category).ToList();
        }

        public List<Product> GetProductByCategoryId(int categoryId)
        {
            return context.Products.Where(p => p.CategoryId == categoryId).Include(img => img.Img).Include(cat => cat.Category).ToList();
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}

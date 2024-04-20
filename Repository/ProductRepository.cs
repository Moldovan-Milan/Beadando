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
    }
}

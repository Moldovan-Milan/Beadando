using Beadando.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beadando.Data
{
    internal class Context : DbContext
    {
        private string connString;

        public DbSet<Images> Images { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Cart { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderElements> OrderElements { get; set; }

        public Context(string connectionString)
        {
            this.connString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(connString);
        }
    }
}

using MoldovanMilanBeadando.Model;
using Microsoft.EntityFrameworkCore;

namespace MoldovanMilanBeadando.Data
{
    internal class Context : DbContext
    {
        private string connString;

        public DbSet<Images> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderElements> OrderElements { get; set; }
        public DbSet<Opinion> Opinions { get; set; }


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

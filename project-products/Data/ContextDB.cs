using Microsoft.EntityFrameworkCore;
using project_products.Data.Map;
using project_products.Models;

namespace project_products.Data
{
    public class ContextDB : DbContext
    {

        public ContextDB(DbContextOptions<ContextDB> options) : base(options) { 
            

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new UserMap());

            base.OnModelCreating(modelBuilder);
        }

    }
}

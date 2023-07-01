using Microsoft.EntityFrameworkCore;
using ProductShop.Models;

namespace ProductShop.DBContext
{
    public class ProductContext : DbContext
    {


        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }

        public DbSet<Product> product { get; set; }

        public DbSet<Feature> features { get; set; }

        public DbSet<Additive> additives { get; set; }
    }
}

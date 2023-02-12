using Artisanaux.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Artisanaux.Service.ProductAPI.DbContexts
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Product>? Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                CategoryName = "Category 1",
                ProductName = "Product 1",
                Price = 1232,
                ImageURL = "http://lorempixel.com/640/480/technics/1"

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                CategoryName = "Category 2",
                ProductName = "Product 2",
                Price = 1232,
                ImageURL = "http://lorempixel.com/640/480/technics/2"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                CategoryName = "Category 3",
                ProductName = "Product 3",
                Price = 1232,
                ImageURL = "http://lorempixel.com/640/480/technics/3"

           });
        
        }
        
    }
}

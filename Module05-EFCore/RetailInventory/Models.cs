using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    // Lab 2: Defining Entities
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; } = new();
    }

    public class Product 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }

    // Lab 2: Setting up Database Context
    public class AppDbContext : DbContext 
    {
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            // Tailored for Linux execution: Stores everything in a local cross-platform file
            optionsBuilder.UseSqlite("Data Source=retail_store.db");
        }
    }
}
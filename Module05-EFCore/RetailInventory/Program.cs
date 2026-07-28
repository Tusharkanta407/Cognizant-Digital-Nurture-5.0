using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RetailInventory
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = new AppDbContext();

            // Ensure database schema is present
            await context.Database.EnsureCreatedAsync();

            Console.WriteLine("--- Lab 4: Inserting Initial Data ---");
            
            // Check if seeding is required to prevent duplication on multiple runs
            if (!await context.Categories.AnyAsync())
            {
                var electronics = new Category { Name = "Electronics" };
                var groceries = new Category { Name = "Groceries" };
                await context.Categories.AddRangeAsync(electronics, groceries);

                var product1 = new Product { Name = "Laptop", Price = 75000, Category = electronics };
                var product2 = new Product { Name = "Rice Bag", Price = 1200, Category = groceries };
                await context.Products.AddRangeAsync(product1, product2);
                
                await context.SaveChangesAsync();
                Console.WriteLine("Initial seed data successfully saved to the database.");
            }
            else
            {
                Console.WriteLine("Data already exists. Skipping insertion step.");
            }

            Console.WriteLine("\n--- Lab 5: Retrieving Data from the Database ---");

            // 1. Retrieve All Products
            Console.WriteLine("Listing All Products:");
            var products = await context.Products.ToListAsync();
            foreach (var p in products)
            {
                Console.WriteLine($" -> {p.Name} - ₹{p.Price}");
            }

            // 2. Find by ID
            Console.WriteLine("\nFinding Product with ID 1:");
            var productById = await context.Products.FindAsync(1);
            Console.WriteLine($" -> Found: {productById?.Name ?? "Not Found"}");

            // 3. FirstOrDefault with Condition
            Console.WriteLine("\nFinding first product over ₹50,000:");
            var expensiveProduct = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
            Console.WriteLine($" -> Expensive Product: {expensiveProduct?.Name ?? "None Found"}");
        }
    }
}
using System;
using System.Collections.Generic;

namespace DSA.Search
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public int CompareTo(Product other)
        {
            return this.ProductId.CompareTo(other.ProductId);
        }

        public override string ToString() => $"[ID: {ProductId}] {ProductName} ({Category})";
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product[] products = {
                new Product { ProductId = 105, ProductName = "Laptop", Category = "Electronics" },
                new Product { ProductId = 101, ProductName = "Mouse", Category = "Electronics" },
                new Product { ProductId = 109, ProductName = "Keyboard", Category = "Electronics" },
                new Product { ProductId = 102, ProductName = "Monitor", Category = "Electronics" }
            };

            Console.WriteLine("--- Linear Search ---");
            var foundLinear = LinearSearch(products, 109);
            Console.WriteLine(foundLinear != null ? $"Found: {foundLinear}" : "Product not found.");

            Console.WriteLine("\n--- Binary Search ---");
            Array.Sort(products); 
            var foundBinary = BinarySearch(products, 102);
            Console.WriteLine(foundBinary != null ? $"Found: {foundBinary}" : "Product not found.");
            
        }

        public static Product LinearSearch(Product[] arr, int targetId)
        {
            foreach (var product in arr)
            {
                if (product.ProductId == targetId) return product;
            }
            return null;
        }

        public static Product BinarySearch(Product[] arr, int targetId)
        {
            int left = 0;
            int right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (arr[mid].ProductId == targetId)
                    return arr[mid];
                
                if (arr[mid].ProductId < targetId)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            return null;
        }
    }
}
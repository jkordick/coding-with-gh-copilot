// Create a Program class with a Main method
// Create a ProductRepository and add at least 10 products across different categories
// Use the ProductQueries class to demonstrate different LINQ queries
// Display the results of each query

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Creating Product Repository and Adding Products");
        Console.WriteLine("----------------------------------------------");
        
        var repository = new ProductRepository();
        
        // Add products
        repository.AddProduct(new Product(1, "Laptop", "Electronics", 1200.00m, 15));
        repository.AddProduct(new Product(2, "Smartphone", "Electronics", 800.00m, 30));
        repository.AddProduct(new Product(3, "Headphones", "Electronics", 150.00m, 50));
        repository.AddProduct(new Product(4, "Mouse", "Computer Accessories", 25.99m, 100));
        repository.AddProduct(new Product(5, "Keyboard", "Computer Accessories", 49.99m, 80));
        repository.AddProduct(new Product(6, "Monitor", "Electronics", 300.00m, 20));
        repository.AddProduct(new Product(7, "T-shirt", "Clothing", 19.99m, 200));
        repository.AddProduct(new Product(8, "Jeans", "Clothing", 49.99m, 150));
        repository.AddProduct(new Product(9, "Sneakers", "Footwear", 89.99m, 60));
        repository.AddProduct(new Product(10, "Coffee Maker", "Kitchen Appliances", 79.99m, 40));
        repository.AddProduct(new Product(11, "Blender", "Kitchen Appliances", 59.99m, 35));
        repository.AddProduct(new Product(12, "Chair", "Furniture", 129.99m, 25));
        repository.AddProduct(new Product(13, "Desk", "Furniture", 249.99m, 8));
        repository.AddProduct(new Product(14, "Bookshelf", "Furniture", 189.99m, 5));
        repository.AddProduct(new Product(15, "Tablet", "Electronics", 399.99m, 25));
        
        // Display all products
        Console.WriteLine("\nAll Products:");
        Console.WriteLine("-------------");
        
        foreach (var product in repository.GetAllProducts())
        {
            Console.WriteLine(product);
        }
        
        // Display total inventory value
        Console.WriteLine($"\nTotal Inventory Value: ${repository.GetTotalInventoryValue():F2}");
        
        // Get most expensive product
        Console.WriteLine("\nMost Expensive Product:");
        Console.WriteLine("----------------------");
        Console.WriteLine(ProductQueries.GetMostExpensiveProduct(repository.GetAllProducts()));
        
        // Get cheapest product
        Console.WriteLine("\nCheapest Product:");
        Console.WriteLine("----------------");
        Console.WriteLine(ProductQueries.GetCheapestProduct(repository.GetAllProducts()));
        
        // Get low stock products (less than 10)
        Console.WriteLine("\nLow Stock Products (Less than 10 in stock):");
        Console.WriteLine("----------------------------------------");
        
        var lowStockProducts = ProductQueries.GetLowStockProducts(repository.GetAllProducts());
        foreach (var product in lowStockProducts)
        {
            Console.WriteLine(product);
        }
        
        // Get top 5 most valuable products
        Console.WriteLine("\nTop 5 Most Valuable Products:");
        Console.WriteLine("---------------------------");
        
        var mostValuableProducts = ProductQueries.GetTopMostValuableProducts(repository.GetAllProducts());
        foreach (var product in mostValuableProducts)
        {
            Console.WriteLine(product);
        }
        
        // Get category summaries
        Console.WriteLine("\nCategory Summaries:");
        Console.WriteLine("------------------");
        
        var categorySummaries = ProductQueries.GetCategorySummaries(repository.GetAllProducts());
        foreach (var summary in categorySummaries)
        {
            Console.WriteLine(summary);
        }
        
        // Filter products by category
        Console.WriteLine("\nElectronics Products:");
        Console.WriteLine("-------------------");
        
        var electronicsProducts = repository.GetProductsByCategory("Electronics");
        foreach (var product in electronicsProducts)
        {
            Console.WriteLine(product);
        }
    }
}
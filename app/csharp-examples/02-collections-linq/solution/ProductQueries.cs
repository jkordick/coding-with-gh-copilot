// Create a static ProductQueries class with LINQ query methods for products
// Add a method to get the most expensive product
// Add a method to get the cheapest product
// Add a method to get products with low stock (less than 10)
// Add a method to get the top 5 most valuable products (Price * StockQuantity)
// Add a method to group products by category and get the count and average price for each category

using System;
using System.Collections.Generic;
using System.Linq;

public static class ProductQueries
{
    public static Product GetMostExpensiveProduct(IEnumerable<Product> products)
    {
        if (products == null || !products.Any())
            throw new ArgumentException("Products collection cannot be null or empty", nameof(products));

        // Using LINQ to find the product with the highest price
        return products.OrderByDescending(p => p.Price).First();
    }

    public static Product GetCheapestProduct(IEnumerable<Product> products)
    {
        if (products == null || !products.Any())
            throw new ArgumentException("Products collection cannot be null or empty", nameof(products));

        // Using LINQ to find the product with the lowest price
        return products.OrderBy(p => p.Price).First();
    }

    public static IEnumerable<Product> GetLowStockProducts(IEnumerable<Product> products, int threshold = 10)
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));

        // Using LINQ to filter products with stock less than the threshold
        return products.Where(p => p.StockQuantity < threshold).ToList();
    }

    public static IEnumerable<Product> GetTopMostValuableProducts(IEnumerable<Product> products, int count = 5)
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));

        if (count <= 0)
            throw new ArgumentException("Count must be greater than zero", nameof(count));

        // Using LINQ to order products by total value (Price * StockQuantity) and take the top ones
        return products
            .OrderByDescending(p => p.CalculateTotalValue())
            .Take(count)
            .ToList();
    }

    public static IEnumerable<CategorySummary> GetCategorySummaries(IEnumerable<Product> products)
    {
        if (products == null)
            throw new ArgumentNullException(nameof(products));

        // Using LINQ to group products by category and calculate statistics
        var categorySummaries = products
            .GroupBy(p => p.Category)
            .Select(g => new CategorySummary
            {
                Category = g.Key,
                ProductCount = g.Count(),
                AveragePrice = g.Average(p => p.Price),
                TotalValue = g.Sum(p => p.CalculateTotalValue())
            })
            .OrderBy(cs => cs.Category)
            .ToList();

        return categorySummaries;
    }
}

public class CategorySummary
{
    public string Category { get; set; }
    public int ProductCount { get; set; }
    public decimal AveragePrice { get; set; }
    public decimal TotalValue { get; set; }

    public override string ToString()
    {
        return $"Category: {Category}, Count: {ProductCount}, Avg Price: ${AveragePrice:F2}, Total Value: ${TotalValue:F2}";
    }
}
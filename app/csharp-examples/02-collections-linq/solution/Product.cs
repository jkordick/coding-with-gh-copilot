// Create a Product class with properties for Id, Name, Category, Price, and StockQuantity
// Include a constructor that accepts all properties
// Add a method to calculate the total value (Price * StockQuantity)

using System;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public Product()
    {
        // Default constructor
    }

    public Product(int id, string name, string category, decimal price, int stockQuantity)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        StockQuantity = stockQuantity;
    }

    public decimal CalculateTotalValue()
    {
        return Price * StockQuantity;
    }

    public override string ToString()
    {
        return $"Product [ID: {Id}] {Name}, Category: {Category}, Price: ${Price:F2}, Stock: {StockQuantity}, Total Value: ${CalculateTotalValue():F2}";
    }
}
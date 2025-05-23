// Create a ProductRepository class that manages a collection of products
// Include methods to add, update, and delete products
// Add methods to get all products, get a product by id, and get products by category
// Add a method to get the total inventory value

using System;
using System.Collections.Generic;
using System.Linq;

public class ProductRepository
{
    private List<Product> _products;

    public ProductRepository()
    {
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        if (_products.Any(p => p.Id == product.Id))
            throw new ArgumentException($"A product with ID {product.Id} already exists.");

        _products.Add(product);
    }

    public void UpdateProduct(Product product)
    {
        if (product == null)
            throw new ArgumentNullException(nameof(product));

        var existingProduct = GetProductById(product.Id);
        if (existingProduct == null)
            throw new KeyNotFoundException($"No product found with ID {product.Id}");

        // Remove the old product and add the updated one
        _products.Remove(existingProduct);
        _products.Add(product);
    }

    public void DeleteProduct(int id)
    {
        var product = GetProductById(id);
        if (product == null)
            throw new KeyNotFoundException($"No product found with ID {id}");

        _products.Remove(product);
    }

    public List<Product> GetAllProducts()
    {
        return _products.ToList();
    }

    public Product GetProductById(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetProductsByCategory(string category)
    {
        if (string.IsNullOrWhiteSpace(category))
            throw new ArgumentException("Category cannot be null or empty", nameof(category));

        return _products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    public decimal GetTotalInventoryValue()
    {
        return _products.Sum(p => p.CalculateTotalValue());
    }
}
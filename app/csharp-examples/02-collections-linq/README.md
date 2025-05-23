# Example 2: Working with Collections and LINQ

In this example, you'll learn how GitHub Copilot can help you work with collections and LINQ queries in C#.

## Tasks

### Task 1: Create a Product Class

1. Create a new file called `Product.cs`
2. Add a comment describing what you want to create:
   ```csharp
   // Create a Product class with properties for Id, Name, Category, Price, and StockQuantity
   // Include a constructor that accepts all properties
   // Add a method to calculate the total value (Price * StockQuantity)
   ```
3. Let GitHub Copilot generate the class for you

### Task 2: Create a Product Repository

1. Create a new file called `ProductRepository.cs`
2. Add a comment describing what you want to create:
   ```csharp
   // Create a ProductRepository class that manages a collection of products
   // Include methods to add, update, and delete products
   // Add methods to get all products, get a product by id, and get products by category
   // Add a method to get the total inventory value
   ```
3. Let GitHub Copilot generate the class for you

### Task 3: Create LINQ Query Methods

1. Create a new file called `ProductQueries.cs`
2. Add a comment describing what you want to create:
   ```csharp
   // Create a static ProductQueries class with LINQ query methods for products
   // Add a method to get the most expensive product
   // Add a method to get the cheapest product
   // Add a method to get products with low stock (less than 10)
   // Add a method to get the top 5 most valuable products (Price * StockQuantity)
   // Add a method to group products by category and get the count and average price for each category
   ```
3. Let GitHub Copilot generate the class for you

### Task 4: Create a Program.cs File

1. Create a new file called `Program.cs`
2. Add a comment describing what you want to create:
   ```csharp
   // Create a Program class with a Main method
   // Create a ProductRepository and add at least 10 products across different categories
   // Use the ProductQueries class to demonstrate different LINQ queries
   // Display the results of each query
   ```
3. Let GitHub Copilot generate the code for you

## GitHub Copilot Tips

- Try asking Copilot to optimize LINQ queries for performance
- Experiment with different query approaches (query syntax vs. method syntax)
- Ask Copilot to add comments explaining how each LINQ query works
- Try modifying the queries to get different results

## Learning Objectives

After completing this example, you should be able to:
- Use GitHub Copilot to generate C# classes that work with collections
- Leverage Copilot to write complex LINQ queries
- Understand how to prompt Copilot for different query approaches

## Sample Solution

Check the `solution` folder for a complete implementation of these tasks.
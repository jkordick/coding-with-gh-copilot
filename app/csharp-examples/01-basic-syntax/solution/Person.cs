// Create a Person class with properties for FirstName, LastName, Age, and Email
// Include a constructor that accepts all properties
// Add a method to return the full name
// Add validation to ensure Age is not negative

using System;

public class Person
{
    private int _age;

    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public int Age
    {
        get { return _age; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Age cannot be negative");
            _age = value;
        }
    }
    
    public string Email { get; set; }

    public Person()
    {
        // Default constructor
    }

    public Person(string firstName, string lastName, int age, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Email = email;
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public override string ToString()
    {
        return $"Person: {GetFullName()}, Age: {Age}, Email: {Email}";
    }
}
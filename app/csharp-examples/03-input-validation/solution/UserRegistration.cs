// Create a User class with properties for Username, Email, Password, DateOfBirth, and PhoneNumber
// Add a UserRegistrationService class that handles user registration
// Include validation for all user fields using the InputValidator
// Store registered users in a collection

using System;
using System.Collections.Generic;

public class User
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime RegistrationDate { get; set; }

    public User()
    {
        RegistrationDate = DateTime.Now;
    }

    public override string ToString()
    {
        return $"Username: {Username}\n" +
               $"Email: {Email}\n" +
               $"Date of Birth: {DateOfBirth:d}\n" +
               $"Phone Number: {PhoneNumber}\n" +
               $"Registration Date: {RegistrationDate:g}";
    }
}

public class UserRegistrationService
{
    private readonly List<User> _users = new List<User>();

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserByUsername(string username)
    {
        return _users.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
    }

    public User GetUserByEmail(string email)
    {
        return _users.Find(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
    }

    public bool RegisterUser(User user, out string errorMessage)
    {
        errorMessage = string.Empty;

        // Validate username
        if (!InputValidator.IsValidLength(user.Username, 3, 20, out errorMessage))
        {
            errorMessage = $"Invalid username: {errorMessage}";
            return false;
        }

        // Check if username already exists
        if (GetUserByUsername(user.Username) != null)
        {
            errorMessage = "Username already exists. Please choose a different username.";
            return false;
        }

        // Validate email
        if (!InputValidator.IsValidEmail(user.Email, out errorMessage))
        {
            errorMessage = $"Invalid email: {errorMessage}";
            return false;
        }

        // Check if email already exists
        if (GetUserByEmail(user.Email) != null)
        {
            errorMessage = "Email address already registered. Please use a different email.";
            return false;
        }

        // Validate password
        if (!InputValidator.IsStrongPassword(user.Password, out errorMessage))
        {
            errorMessage = $"Invalid password: {errorMessage}";
            return false;
        }

        // Validate date of birth (users must be between 13 and 120 years old)
        if (!InputValidator.IsValidDate(user.DateOfBirth, 13, 120, out errorMessage))
        {
            errorMessage = $"Invalid date of birth: {errorMessage}";
            return false;
        }

        // Validate phone number
        if (!InputValidator.IsValidPhoneNumber(user.PhoneNumber, out errorMessage))
        {
            errorMessage = $"Invalid phone number: {errorMessage}";
            return false;
        }

        // All validations passed, add user
        _users.Add(user);
        return true;
    }
}
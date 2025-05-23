// Create an InputValidator class with methods to validate different types of input
// Add methods to validate: email addresses, phone numbers, dates, numeric ranges, and text length
// Each method should return a bool indicating whether the input is valid
// Include helpful error messages for invalid input

using System;
using System.Text.RegularExpressions;

public class InputValidator
{
    // Validate email address format
    public static bool IsValidEmail(string email, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        if (string.IsNullOrWhiteSpace(email))
        {
            errorMessage = "Email address cannot be empty.";
            return false;
        }
        
        // Regular expression for validating email
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        
        if (!Regex.IsMatch(email, pattern))
        {
            errorMessage = "Invalid email format. Please enter a valid email address (e.g., user@example.com).";
            return false;
        }
        
        return true;
    }
    
    // Validate phone number format
    public static bool IsValidPhoneNumber(string phoneNumber, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            errorMessage = "Phone number cannot be empty.";
            return false;
        }
        
        // Remove any non-digit characters for validation
        string digitsOnly = Regex.Replace(phoneNumber, @"\D", "");
        
        // Check if we have a valid number of digits (10-15)
        if (digitsOnly.Length < 10 || digitsOnly.Length > 15)
        {
            errorMessage = "Phone number should have between 10 and 15 digits.";
            return false;
        }
        
        return true;
    }
    
    // Validate date is within acceptable range
    public static bool IsValidDate(DateTime date, int minAge, int maxAge, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        DateTime minDate = DateTime.Now.AddYears(-maxAge);
        DateTime maxDate = DateTime.Now.AddYears(-minAge);
        
        if (date < minDate)
        {
            errorMessage = $"Date is too far in the past. Maximum age is {maxAge} years.";
            return false;
        }
        
        if (date > maxDate)
        {
            errorMessage = $"Date is too recent. Minimum age is {minAge} years.";
            return false;
        }
        
        return true;
    }
    
    // Validate numeric value is within range
    public static bool IsInRange(int value, int min, int max, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        if (value < min || value > max)
        {
            errorMessage = $"Value must be between {min} and {max}.";
            return false;
        }
        
        return true;
    }
    
    // Validate text length
    public static bool IsValidLength(string text, int minLength, int maxLength, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        if (string.IsNullOrEmpty(text))
        {
            errorMessage = "Text cannot be empty.";
            return false;
        }
        
        if (text.Length < minLength)
        {
            errorMessage = $"Text must be at least {minLength} characters long.";
            return false;
        }
        
        if (text.Length > maxLength)
        {
            errorMessage = $"Text cannot exceed {maxLength} characters.";
            return false;
        }
        
        return true;
    }
    
    // Validate password strength
    public static bool IsStrongPassword(string password, out string errorMessage)
    {
        errorMessage = string.Empty;
        
        if (string.IsNullOrWhiteSpace(password))
        {
            errorMessage = "Password cannot be empty.";
            return false;
        }
        
        if (password.Length < 8)
        {
            errorMessage = "Password must be at least 8 characters long.";
            return false;
        }
        
        if (!Regex.IsMatch(password, @"[A-Z]"))
        {
            errorMessage = "Password must contain at least one uppercase letter.";
            return false;
        }
        
        if (!Regex.IsMatch(password, @"[a-z]"))
        {
            errorMessage = "Password must contain at least one lowercase letter.";
            return false;
        }
        
        if (!Regex.IsMatch(password, @"[0-9]"))
        {
            errorMessage = "Password must contain at least one number.";
            return false;
        }
        
        if (!Regex.IsMatch(password, @"[^a-zA-Z0-9]"))
        {
            errorMessage = "Password must contain at least one special character.";
            return false;
        }
        
        return true;
    }
}
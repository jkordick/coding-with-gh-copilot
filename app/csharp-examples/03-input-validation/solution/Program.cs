// Create a console application that allows users to register new accounts
// The program should prompt for each piece of information with clear instructions
// Validate each input and display appropriate error messages if validation fails
// After successful registration, display a summary of the registered user information
// Allow the user to register multiple accounts in a single session

using System;

class Program
{
    static void Main(string[] args)
    {
        var registrationService = new UserRegistrationService();
        bool continueRegistration = true;

        Console.WriteLine("=== User Registration System ===");
        
        while (continueRegistration)
        {
            RegisterNewUser(registrationService);
            
            Console.WriteLine("\nWould you like to register another user? (y/n)");
            string response = Console.ReadLine().Trim().ToLower();
            continueRegistration = response == "y" || response == "yes";
            
            Console.Clear();
            if (continueRegistration)
            {
                Console.WriteLine("=== User Registration System ===");
            }
        }
        
        DisplayAllRegisteredUsers(registrationService);
        
        Console.WriteLine("\nThank you for using the User Registration System. Press any key to exit.");
        Console.ReadKey();
    }
    
    static void RegisterNewUser(UserRegistrationService registrationService)
    {
        User user = new User();
        
        // Get and validate username
        user.Username = GetValidInput(
            "Enter username (3-20 characters): ",
            input => InputValidator.IsValidLength(input, 3, 20, out _),
            "Username must be between 3 and 20 characters.");
        
        // Check if username already exists
        while (registrationService.GetUserByUsername(user.Username) != null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Username already exists. Please choose a different username.");
            Console.ResetColor();
            user.Username = GetValidInput(
                "Enter username (3-20 characters): ",
                input => InputValidator.IsValidLength(input, 3, 20, out _),
                "Username must be between 3 and 20 characters.");
        }
        
        // Get and validate email
        user.Email = GetValidInput(
            "Enter email address: ",
            input => InputValidator.IsValidEmail(input, out _),
            "Please enter a valid email address (e.g., user@example.com).");
        
        // Check if email already exists
        while (registrationService.GetUserByEmail(user.Email) != null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Email address already registered. Please use a different email.");
            Console.ResetColor();
            user.Email = GetValidInput(
                "Enter email address: ",
                input => InputValidator.IsValidEmail(input, out _),
                "Please enter a valid email address (e.g., user@example.com).");
        }
        
        // Get and validate password
        user.Password = GetValidInput(
            "Enter password (must contain uppercase, lowercase, number, and special character): ",
            input => InputValidator.IsStrongPassword(input, out _),
            "Password must be at least 8 characters and include uppercase, lowercase, number, and special character.");
        
        // Get and validate date of birth
        user.DateOfBirth = GetValidDate(
            "Enter date of birth (MM/DD/YYYY): ",
            "Please enter a valid date in the format MM/DD/YYYY.");
        
        // Get and validate phone number
        user.PhoneNumber = GetValidInput(
            "Enter phone number: ",
            input => InputValidator.IsValidPhoneNumber(input, out _),
            "Please enter a valid phone number with 10-15 digits.");
        
        // Register the user
        string errorMessage;
        if (registrationService.RegisterUser(user, out errorMessage))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRegistration Successful!");
            Console.ResetColor();
            
            Console.WriteLine("\nUser Information:");
            Console.WriteLine("----------------");
            Console.WriteLine(user.ToString());
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nRegistration Failed: {errorMessage}");
            Console.ResetColor();
        }
    }
    
    static string GetValidInput(string prompt, Func<string, bool> validationFunc, string errorMessage)
    {
        string input;
        bool isValid;
        
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine().Trim();
            isValid = validationFunc(input);
            
            if (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ResetColor();
            }
        } while (!isValid);
        
        return input;
    }
    
    static DateTime GetValidDate(string prompt, string errorMessage)
    {
        DateTime date;
        bool isValid;
        string errorMsg;
        
        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine().Trim();
            isValid = DateTime.TryParse(input, out date) && 
                      InputValidator.IsValidDate(date, 13, 120, out errorMsg);
            
            if (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMsg != string.Empty ? errorMsg : errorMessage);
                Console.ResetColor();
            }
        } while (!isValid);
        
        return date;
    }
    
    static void DisplayAllRegisteredUsers(UserRegistrationService registrationService)
    {
        var users = registrationService.GetAllUsers();
        
        if (users.Count == 0)
        {
            Console.WriteLine("No users registered.");
            return;
        }
        
        Console.WriteLine("\n=== All Registered Users ===");
        Console.WriteLine($"Total Users: {users.Count}");
        
        for (int i = 0; i < users.Count; i++)
        {
            Console.WriteLine($"\nUser #{i + 1}");
            Console.WriteLine("----------");
            Console.WriteLine(users[i].ToString());
        }
    }
}
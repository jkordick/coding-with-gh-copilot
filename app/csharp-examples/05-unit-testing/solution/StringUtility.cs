// Create a StringUtility class with methods for common string operations
// Add methods for reversing a string, checking if a string is a palindrome
// Add a method to count occurrences of a substring
// Add a method to convert a string to title case

using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace UnitTestingDemo
{
    public class StringUtility
    {
        /// <summary>
        /// Reverses the characters in a string.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>A new string with the characters in reverse order.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public string Reverse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");

            if (input.Length <= 1)
                return input;

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        /// <summary>
        /// Checks if a string is a palindrome (reads the same forwards and backwards).
        /// </summary>
        /// <param name="input">The string to check.</param>
        /// <param name="ignoreCase">Whether to ignore case when comparing characters.</param>
        /// <param name="ignoreNonAlphanumeric">Whether to ignore non-alphanumeric characters.</param>
        /// <returns>True if the string is a palindrome, false otherwise.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public bool IsPalindrome(string input, bool ignoreCase = true, bool ignoreNonAlphanumeric = true)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");

            if (input.Length <= 1)
                return true;

            // Preprocess the string if needed
            if (ignoreNonAlphanumeric)
                input = Regex.Replace(input, @"[^a-zA-Z0-9]", "");

            if (ignoreCase)
                input = input.ToLower();

            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Counts the number of occurrences of a substring within a string.
        /// </summary>
        /// <param name="input">The string to search in.</param>
        /// <param name="substring">The substring to search for.</param>
        /// <param name="ignoreCase">Whether to ignore case when comparing.</param>
        /// <returns>The number of occurrences of the substring.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input or substring is null.</exception>
        /// <exception cref="ArgumentException">Thrown when substring is empty.</exception>
        public int CountOccurrences(string input, string substring, bool ignoreCase = false)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            
            if (substring == null)
                throw new ArgumentNullException(nameof(substring), "Substring cannot be null.");
            
            if (substring == string.Empty)
                throw new ArgumentException("Substring cannot be empty.", nameof(substring));

            if (input == string.Empty)
                return 0;

            // Use regular expressions for case-insensitive search if needed
            if (ignoreCase)
            {
                return Regex.Matches(input, Regex.Escape(substring), RegexOptions.IgnoreCase).Count;
            }
            else
            {
                int count = 0;
                int index = 0;
                
                while ((index = input.IndexOf(substring, index, StringComparison.Ordinal)) != -1)
                {
                    count++;
                    index += substring.Length;
                }
                
                return count;
            }
        }

        /// <summary>
        /// Converts a string to title case.
        /// </summary>
        /// <param name="input">The string to convert.</param>
        /// <returns>The string converted to title case.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input is null.</exception>
        public string ToTitleCase(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");

            if (input == string.Empty)
                return input;

            // Use TextInfo to properly handle title case based on culture
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        /// Truncates a string to a specified maximum length and adds an ellipsis if truncated.
        /// </summary>
        /// <param name="input">The string to truncate.</param>
        /// <param name="maxLength">The maximum length of the output string, including the ellipsis if added.</param>
        /// <param name="ellipsis">The string to append if truncation occurs.</param>
        /// <returns>The truncated string, with ellipsis if truncated.</returns>
        /// <exception cref="ArgumentNullException">Thrown when input or ellipsis is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when maxLength is less than the length of the ellipsis.</exception>
        public string Truncate(string input, int maxLength, string ellipsis = "...")
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            
            if (ellipsis == null)
                throw new ArgumentNullException(nameof(ellipsis), "Ellipsis cannot be null.");
            
            if (maxLength < ellipsis.Length)
                throw new ArgumentOutOfRangeException(nameof(maxLength), "Max length must be at least the length of the ellipsis.");

            if (input.Length <= maxLength)
                return input;

            return input.Substring(0, maxLength - ellipsis.Length) + ellipsis;
        }
    }
}
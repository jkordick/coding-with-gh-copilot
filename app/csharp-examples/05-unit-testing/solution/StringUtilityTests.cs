// Create unit tests for the StringUtility class using xUnit
// Test each string operation with various inputs
// Include tests for edge cases such as empty strings, null inputs
// Use data-driven tests to check multiple inputs with a single test method

using System;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestingDemo.Tests
{
    public class StringUtilityTests
    {
        private readonly StringUtility _stringUtility;
        private readonly ITestOutputHelper _output;

        public StringUtilityTests(ITestOutputHelper output)
        {
            _stringUtility = new StringUtility();
            _output = output;
        }

        #region Reverse Tests

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("hello", "olleh")]
        [InlineData("12345", "54321")]
        [InlineData("a", "a")]
        [InlineData("", "")]
        [InlineData("abcba", "abcba")]
        [InlineData("Hello World", "dlroW olleH")]
        public void Reverse_WithValidInput_ReturnsReversedString(string input, string expected)
        {
            // Arrange
            _output.WriteLine($"Testing Reverse(\"{input}\") = \"{expected}\"");
            
            // Act
            string result = _stringUtility.Reverse(input);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void Reverse_WithNullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            
            _output.WriteLine("Testing Reverse(null) throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.Reverse(input));
            Assert.Equal("input", exception.ParamName);
        }

        #endregion

        #region IsPalindrome Tests

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("racecar", true)]
        [InlineData("hello", false)]
        [InlineData("A man a plan a canal Panama", true)]
        [InlineData("No lemon, no melon", true)]
        [InlineData("", true)]
        [InlineData("a", true)]
        [InlineData("ab", false)]
        [InlineData("Madam, I'm Adam", true)]
        [InlineData("12321", true)]
        [InlineData("12345", false)]
        public void IsPalindrome_WithDefaultOptions_ReturnsExpectedResult(string input, bool expected)
        {
            // Arrange
            _output.WriteLine($"Testing IsPalindrome(\"{input}\") = {expected}");
            
            // Act
            bool result = _stringUtility.IsPalindrome(input);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("Racecar", true, true)]
        [InlineData("Racecar", false, false)]
        [InlineData("A man a plan a canal Panama", true, true)]
        [InlineData("A man a plan a canal Panama", false, false)]
        public void IsPalindrome_WithIgnoreCase_ReturnsExpectedResult(string input, bool ignoreCase, bool expected)
        {
            // Arrange
            _output.WriteLine($"Testing IsPalindrome(\"{input}\", ignoreCase: {ignoreCase}) = {expected}");
            
            // Act
            bool result = _stringUtility.IsPalindrome(input, ignoreCase, true);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("A man a plan a canal Panama", true, true)]
        [InlineData("A man a plan a canal Panama", false, false)]
        [InlineData("race car", true, true)]
        [InlineData("race car", false, false)]
        public void IsPalindrome_WithIgnoreNonAlphanumeric_ReturnsExpectedResult(string input, bool ignoreNonAlphanumeric, bool expected)
        {
            // Arrange
            _output.WriteLine($"Testing IsPalindrome(\"{input}\", ignoreNonAlphanumeric: {ignoreNonAlphanumeric}) = {expected}");
            
            // Act
            bool result = _stringUtility.IsPalindrome(input, true, ignoreNonAlphanumeric);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void IsPalindrome_WithNullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            
            _output.WriteLine("Testing IsPalindrome(null) throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.IsPalindrome(input));
            Assert.Equal("input", exception.ParamName);
        }

        #endregion

        #region CountOccurrences Tests

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("hello world", "l", 3)]
        [InlineData("hello world", "o", 2)]
        [InlineData("hello world", "ll", 1)]
        [InlineData("hello world", "z", 0)]
        [InlineData("hello hello hello", "hello", 3)]
        [InlineData("aaaaa", "aa", 2)]  // Overlapping matches are not counted
        [InlineData("", "a", 0)]
        public void CountOccurrences_WithValidInputs_ReturnsExpectedCount(string input, string substring, int expected)
        {
            // Arrange
            _output.WriteLine($"Testing CountOccurrences(\"{input}\", \"{substring}\") = {expected}");
            
            // Act
            int result = _stringUtility.CountOccurrences(input, substring);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("Hello World", "hello", 0, false)]
        [InlineData("Hello World", "hello", 1, true)]
        [InlineData("Hello Hello", "hello", 2, true)]
        [InlineData("Hello HELLO", "hello", 2, true)]
        public void CountOccurrences_WithIgnoreCase_ReturnsExpectedCount(string input, string substring, int expected, bool ignoreCase)
        {
            // Arrange
            _output.WriteLine($"Testing CountOccurrences(\"{input}\", \"{substring}\", ignoreCase: {ignoreCase}) = {expected}");
            
            // Act
            int result = _stringUtility.CountOccurrences(input, substring, ignoreCase);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void CountOccurrences_WithNullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            string substring = "test";
            
            _output.WriteLine("Testing CountOccurrences(null, \"test\") throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.CountOccurrences(input, substring));
            Assert.Equal("input", exception.ParamName);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void CountOccurrences_WithNullSubstring_ThrowsArgumentNullException()
        {
            // Arrange
            string input = "test";
            string substring = null;
            
            _output.WriteLine("Testing CountOccurrences(\"test\", null) throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.CountOccurrences(input, substring));
            Assert.Equal("substring", exception.ParamName);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void CountOccurrences_WithEmptySubstring_ThrowsArgumentException()
        {
            // Arrange
            string input = "test";
            string substring = "";
            
            _output.WriteLine("Testing CountOccurrences(\"test\", \"\") throws ArgumentException");
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _stringUtility.CountOccurrences(input, substring));
        }

        #endregion

        #region ToTitleCase Tests

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("hello world", "Hello World")]
        [InlineData("HELLO WORLD", "Hello World")]
        [InlineData("hello WORLD", "Hello World")]
        [InlineData("hElLo WoRlD", "Hello World")]
        [InlineData("", "")]
        [InlineData("a", "A")]
        [InlineData("john smith", "John Smith")]
        [InlineData("john-smith", "John-smith")] // Note: This depends on current culture behavior
        public void ToTitleCase_WithValidInput_ReturnsExpectedResult(string input, string expected)
        {
            // Arrange
            _output.WriteLine($"Testing ToTitleCase(\"{input}\") = \"{expected}\"");
            
            // Act
            string result = _stringUtility.ToTitleCase(input);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void ToTitleCase_WithNullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            
            _output.WriteLine("Testing ToTitleCase(null) throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.ToTitleCase(input));
            Assert.Equal("input", exception.ParamName);
        }

        #endregion

        #region Truncate Tests

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("Hello, World!", 5, "...")]
        [InlineData("Hello, World!", 15, "Hello, World!")]
        [InlineData("Hello, World!", 10, "Hello, ...")]
        [InlineData("", 5, "")]
        [InlineData("Hi", 2, "Hi")]
        public void Truncate_WithValidInputs_ReturnsExpectedResult(string input, int maxLength, string expected)
        {
            // Arrange
            string ellipsis = "...";
            if (input.Length <= maxLength)
                expected = input;
            
            _output.WriteLine($"Testing Truncate(\"{input}\", {maxLength}, \"{ellipsis}\") = \"{expected}\"");
            
            // Act
            string result = _stringUtility.Truncate(input, maxLength);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "StringOperations")]
        [InlineData("Hello, World!", 5, "..", "Hel..")]
        [InlineData("Hello, World!", 5, "", "Hello")]
        [InlineData("Hello, World!", 10, "_", "Hello, Wor_")]
        public void Truncate_WithCustomEllipsis_ReturnsExpectedResult(string input, int maxLength, string ellipsis, string expected)
        {
            // Arrange
            _output.WriteLine($"Testing Truncate(\"{input}\", {maxLength}, \"{ellipsis}\") = \"{expected}\"");
            
            // Act
            string result = _stringUtility.Truncate(input, maxLength, ellipsis);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void Truncate_WithNullInput_ThrowsArgumentNullException()
        {
            // Arrange
            string input = null;
            
            _output.WriteLine("Testing Truncate(null, 5) throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.Truncate(input, 5));
            Assert.Equal("input", exception.ParamName);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void Truncate_WithNullEllipsis_ThrowsArgumentNullException()
        {
            // Arrange
            string input = "test";
            string ellipsis = null;
            
            _output.WriteLine("Testing Truncate(\"test\", 5, null) throws ArgumentNullException");
            
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => _stringUtility.Truncate(input, 5, ellipsis));
            Assert.Equal("ellipsis", exception.ParamName);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void Truncate_WithMaxLengthLessThanEllipsisLength_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            string input = "test";
            string ellipsis = "...";
            int maxLength = 2;
            
            _output.WriteLine($"Testing Truncate(\"test\", {maxLength}, \"{ellipsis}\") throws ArgumentOutOfRangeException");
            
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _stringUtility.Truncate(input, maxLength, ellipsis));
        }

        #endregion
    }
}
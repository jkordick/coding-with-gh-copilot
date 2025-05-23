// Create unit tests for the Calculator class using xUnit
// Test each arithmetic operation with various inputs
// Include tests for edge cases and exceptions
// Add appropriate test categories and meaningful test names

using System;
using Xunit;
using Xunit.Abstractions;

namespace UnitTestingDemo.Tests
{
    public class CalculatorTests
    {
        private readonly Calculator _calculator;
        private readonly ITestOutputHelper _output;

        public CalculatorTests(ITestOutputHelper output)
        {
            _calculator = new Calculator();
            _output = output;
        }

        [Theory]
        [Trait("Category", "BasicOperations")]
        [InlineData(5, 3, 8)]
        [InlineData(-5, 3, -2)]
        [InlineData(5, -3, 2)]
        [InlineData(-5, -3, -8)]
        [InlineData(0, 0, 0)]
        [InlineData(double.MaxValue, 1, double.MaxValue + 1)]
        public void Add_WithValidInputs_ReturnsExpectedSum(double a, double b, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing Add({a}, {b}) = {expected}");
            
            // Act
            double result = _calculator.Add(a, b);
            
            // Assert
            Assert.Equal(expected, result, 10);
        }

        [Theory]
        [Trait("Category", "BasicOperations")]
        [InlineData(5, 3, 2)]
        [InlineData(-5, 3, -8)]
        [InlineData(5, -3, 8)]
        [InlineData(-5, -3, -2)]
        [InlineData(0, 0, 0)]
        public void Subtract_WithValidInputs_ReturnsExpectedDifference(double a, double b, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing Subtract({a}, {b}) = {expected}");
            
            // Act
            double result = _calculator.Subtract(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "BasicOperations")]
        [InlineData(5, 3, 15)]
        [InlineData(-5, 3, -15)]
        [InlineData(5, -3, -15)]
        [InlineData(-5, -3, 15)]
        [InlineData(0, 5, 0)]
        [InlineData(5, 0, 0)]
        public void Multiply_WithValidInputs_ReturnsExpectedProduct(double a, double b, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing Multiply({a}, {b}) = {expected}");
            
            // Act
            double result = _calculator.Multiply(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [Trait("Category", "BasicOperations")]
        [InlineData(6, 3, 2)]
        [InlineData(-6, 3, -2)]
        [InlineData(6, -3, -2)]
        [InlineData(-6, -3, 2)]
        [InlineData(0, 5, 0)]
        public void Divide_WithValidInputs_ReturnsExpectedQuotient(double a, double b, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing Divide({a}, {b}) = {expected}");
            
            // Act
            double result = _calculator.Divide(a, b);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void Divide_WithZeroDivisor_ThrowsDivideByZeroException()
        {
            // Arrange
            double a = 5;
            double b = 0;
            
            _output.WriteLine($"Testing Divide({a}, {b}) throws DivideByZeroException");
            
            // Act & Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }

        [Theory]
        [Trait("Category", "AdvancedOperations")]
        [InlineData(4, 2)]
        [InlineData(9, 3)]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(0.25, 0.5)]
        public void SquareRoot_WithValidInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing SquareRoot({input}) = {expected}");
            
            // Act
            double result = _calculator.SquareRoot(input);
            
            // Assert
            Assert.Equal(expected, result, 10);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void SquareRoot_WithNegativeInput_ThrowsArgumentException()
        {
            // Arrange
            double input = -4;
            
            _output.WriteLine($"Testing SquareRoot({input}) throws ArgumentException");
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.SquareRoot(input));
        }

        [Theory]
        [Trait("Category", "AdvancedOperations")]
        [InlineData(2, 3, 8)]
        [InlineData(3, 2, 9)]
        [InlineData(2, 0, 1)]
        [InlineData(0, 5, 0)]
        [InlineData(-2, 2, 4)]
        [InlineData(-2, 3, -8)]
        public void Power_WithValidInputs_ReturnsExpectedResult(double baseNumber, double exponent, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing Power({baseNumber}, {exponent}) = {expected}");
            
            // Act
            double result = _calculator.Power(baseNumber, exponent);
            
            // Assert
            Assert.Equal(expected, result, 10);
        }

        [Theory]
        [Trait("Category", "AdvancedOperations")]
        [InlineData(25, 100, 25)]
        [InlineData(50, 100, 50)]
        [InlineData(0, 100, 0)]
        [InlineData(200, 100, 200)]
        public void CalculatePercentage_WithValidInputs_ReturnsExpectedPercentage(double value, double total, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing CalculatePercentage({value}, {total}) = {expected}");
            
            // Act
            double result = _calculator.CalculatePercentage(value, total);
            
            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        [Trait("Category", "Exceptions")]
        public void CalculatePercentage_WithZeroTotal_ThrowsArgumentException()
        {
            // Arrange
            double value = 5;
            double total = 0;
            
            _output.WriteLine($"Testing CalculatePercentage({value}, {total}) throws ArgumentException");
            
            // Act & Assert
            Assert.Throws<ArgumentException>(() => _calculator.CalculatePercentage(value, total));
        }

        [Theory]
        [Trait("Category", "BasicOperations")]
        [InlineData(5, 5)]
        [InlineData(-5, 5)]
        [InlineData(0, 0)]
        public void AbsoluteValue_WithValidInputs_ReturnsExpectedResult(double input, double expected)
        {
            // Arrange
            _output.WriteLine($"Testing AbsoluteValue({input}) = {expected}");
            
            // Act
            double result = _calculator.AbsoluteValue(input);
            
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
// Create a Calculator class with methods for basic arithmetic operations
// Add methods for addition, subtraction, multiplication, division
// Add a method to calculate the square root of a number
// Add input validation and appropriate exception handling

using System;

namespace UnitTestingDemo
{
    public class Calculator
    {
        /// <summary>
        /// Adds two numbers and returns the result.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Add(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Subtracts the second number from the first and returns the result.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number to subtract from the first.</param>
        /// <returns>The difference between the two numbers.</returns>
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers and returns the result.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Divides the first number by the second and returns the result.
        /// </summary>
        /// <param name="a">The dividend.</param>
        /// <param name="b">The divisor.</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the divisor is zero.</exception>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }

            return a / b;
        }

        /// <summary>
        /// Calculates the square root of a number.
        /// </summary>
        /// <param name="a">The number to calculate the square root of.</param>
        /// <returns>The square root of the number.</returns>
        /// <exception cref="ArgumentException">Thrown when the input is negative.</exception>
        public double SquareRoot(double a)
        {
            if (a < 0)
            {
                throw new ArgumentException("Cannot calculate square root of a negative number.", nameof(a));
            }

            return Math.Sqrt(a);
        }

        /// <summary>
        /// Raises a number to a specified power.
        /// </summary>
        /// <param name="baseNumber">The base number.</param>
        /// <param name="exponent">The exponent.</param>
        /// <returns>The result of raising the base number to the specified power.</returns>
        public double Power(double baseNumber, double exponent)
        {
            return Math.Pow(baseNumber, exponent);
        }

        /// <summary>
        /// Calculates the percentage of a total.
        /// </summary>
        /// <param name="value">The value to calculate the percentage of.</param>
        /// <param name="total">The total value.</param>
        /// <returns>The percentage as a value between 0 and 100.</returns>
        /// <exception cref="ArgumentException">Thrown when the total is zero.</exception>
        public double CalculatePercentage(double value, double total)
        {
            if (total == 0)
            {
                throw new ArgumentException("Total cannot be zero.", nameof(total));
            }

            return (value / total) * 100;
        }

        /// <summary>
        /// Calculates the absolute value of a number.
        /// </summary>
        /// <param name="value">The number to get the absolute value of.</param>
        /// <returns>The absolute value of the number.</returns>
        public double AbsoluteValue(double value)
        {
            return Math.Abs(value);
        }
    }
}
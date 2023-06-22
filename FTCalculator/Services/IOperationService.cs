using System;

namespace FTCalculator.Services
{
    public interface IOperationService
    {
        /// <summary>
        /// Calculates the sum of two numbers
        /// </summary>
        /// <param name="valueOne">The first number</param>
        /// <param name="valueTwo">The second number</param>
        /// <returns>The sum of two numbers</returns>
        double Add(double valueOne, double valueTwo);

        /// <summary>
        /// Calculates the difference of two numbers
        /// </summary>
        /// <param name="valueOne">The first number</param>
        /// <param name="valueTwo">The second number</param>
        /// <returns>The difference of two numbers</returns>
        double Subtract(double valueOne, double valueTwo);

        /// <summary>
        /// Calculates the division of two numbers
        /// </summary>
        /// <param name="valueOne">The first number</param>
        /// <param name="valueTwo">The second number</param>
        /// <returns>The result of a division of two numbers</returns>
        /// <exception cref="DivideByZeroException">A number cannot be divided by zero</exception>
        double Divide(double valueOne, double valueTwo);

        /// <summary>
        /// Calculates the product of two numbers
        /// </summary>
        /// <param name="valueOne">The first number</param>
        /// <param name="valueTwo">The second number</param>
        /// <returns>The product of two numbers</returns>
        double Mutiply(double valueOne, double valueTwo);

        /// <summary>
        /// Calculates the factorial of an integer
        /// </summary>
        /// <param name="value">The integer to be factorialized</param>
        /// <returns>The factorial of the given integer</returns>
        /// <exception cref="ArgumentException">This method cannot compute the factorial of a negative integer</exception>
        int Factorial(int value);
    }
}

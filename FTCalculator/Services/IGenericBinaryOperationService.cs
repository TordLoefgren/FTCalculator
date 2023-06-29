using FTCalculator.Enums;
using System;
using System.Numerics;

namespace FTCalculator.Services
{
    /// <summary>
    /// Service class that performs basic binary operations on generic numbers.
    /// </summary>
    public interface IGenericBinaryOperationService
    {
        /// <summary>
        /// Calculates the sum of two numbers.
        /// </summary>
        /// <param name="valueOne">The first number.</param>
        /// <param name="valueTwo">The second number.</param>
        /// <returns>The sum of two numbers.</returns>
        T Add<T>(T valueOne, T valueTwo) where T : INumber<T>;

        /// <summary>
        /// Calculates the difference of two numbers.
        /// </summary>
        /// <param name="valueOne">The first number.</param>
        /// <param name="valueTwo">The second number.</param>
        /// <returns>The difference of two numbers.</returns>
        T Subtract<T>(T valueOne, T valueTwo) where T : INumber<T>;

        /// <summary>
        /// Calculates the division of two numbers.
        /// </summary>
        /// <param name="valueOne">The first number.</param>
        /// <param name="valueTwo">The second number.</param>
        /// <returns>The quotient of two numbers.</returns>
        /// <exception cref="DivideByZeroException">A number cannot be divided by zero.</exception>
        T Divide<T>(T valueOne, T valueTwo) where T : INumber<T>;

        /// <summary>
        /// Calculates the product of two numbers.
        /// </summary>
        /// <param name="valueOne">The first number.</param>
        /// <param name="valueTwo">The second number.</param>
        /// <returns>The product of two numbers.</returns>
        T Multiply<T>(T valueOne, T valueTwo) where T : INumber<T>;

        /// <summary>
        /// Calculates the computation result of two numbers by using a supplied operator.
        /// </summary>
        /// <param name="op">The Operator to be used to calculate the result.</param>
        /// <param name="valueOne">The first number.</param>
        /// <param name="valueTwo">The second number.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="ArgumentException">Invalid argument.</exception>
        T ComputeByOperator<T>(Operator op, T valueOne, T valueTwo) where T : INumber<T>;
    }
}

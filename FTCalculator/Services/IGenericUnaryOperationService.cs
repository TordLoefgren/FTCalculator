using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.Services
{
    /// <summary>
    /// Represents a unary calculator operation-service.
    /// </summary>
    public interface IGenericUnaryOperationService
    {
        /// <summary>
        /// Calculates the factorial of the given non-negative integer.
        /// </summary>
        /// <param name="n">The integer to compute the factorial of.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">The integer must be non-negative.</exception>
        int Factorial(int n);

        /// <summary>
        /// Calculates the percentage 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="n"></param>
        /// <returns></returns>
        T Square<T>(T n) where T : INumber<T>;
    }
}

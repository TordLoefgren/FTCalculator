using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.Services
{
    public class GenericUnaryOperationService : IGenericUnaryOperationService
    {
        public int Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("The integer must be non-negative");
            }

            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        public T Square<T>(T n) where T : INumber<T>
        {
            return n * n;
        }
    }
}

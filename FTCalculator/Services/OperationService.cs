using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.Services
{
    public class OperationService : IOperationService
    {
        public float Add(float valueOne, float valueTwo)
        {
            return valueOne + valueTwo;
        }

        public float Divide(float valueOne, float valueTwo)
        {
            if (valueTwo == 0)
            {
                // Do nothing in UI?
                throw new DivideByZeroException();
            }
            return valueOne / valueTwo;
        }

        public float Mutiply(float valueOne, float valueTwo)
        {
            return valueOne * valueTwo;
        }

        public float Subtract(float valueOne, float valueTwo)
        {
            return valueOne - valueTwo;
        }

        public int Factorial(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Input cannot be negative.");
            }

            if (value == 0)
            {
                return 1;
            }
            else
            {
                return value * Factorial(value - 1);
            }
        }
    }
}

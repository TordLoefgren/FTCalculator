using System;

namespace FTCalculator.Services
{
    public class OperationService : IOperationService
    {
        public double Add(double valueOne, double valueTwo)
        {
            return valueOne + valueTwo;
        }

        public double Divide(double valueOne, double valueTwo)
        {
            if (valueTwo == 0)
            {
                // Do nothing in UI?
                throw new DivideByZeroException("You cannot divide a number by zero.");
            }
            return valueOne / valueTwo;
        }

        public double Mutiply(double valueOne, double valueTwo)
        {
            return valueOne * valueTwo;
        }

        public double Subtract(double valueOne, double valueTwo)
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

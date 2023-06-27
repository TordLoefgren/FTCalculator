using FTCalculator.Enums;
using System;
using System.Numerics;

namespace FTCalculator.Services
{
    /// <summary>
    /// Represents a generic calculator operation-service.
    /// </summary>
    public class GenericOperationService : IGenericOperationService
    {
        public T Add<T>(T valueOne, T valueTwo) where T : INumber<T>
        {
            return valueOne + valueTwo;
        }

        public T Divide<T>(T valueOne, T valueTwo) where T : INumber<T>
        {
            return valueOne / valueTwo;
        }

        public T Multiply<T>(T valueOne, T valueTwo) where T : INumber<T>
        {
            return valueOne * valueTwo;
        }

        public T Subtract<T>(T valueOne, T valueTwo) where T : INumber<T>
        {
            return valueOne - valueTwo;
        }

        public T ComputeByOperator<T>(Operator? op, T valueOne, T valueTwo) where T : INumber<T>
        {
            switch(op)
            {
                case Operator.Add:
                    return this.Add(valueOne, valueTwo);
                case Operator.Subtract:
                    return this.Subtract(valueOne, valueTwo);
                case Operator.Multiply:
                    return this.Multiply(valueOne, valueTwo);
                case Operator.Divide:
                    return this.Divide(valueOne, valueTwo);
                default:
                    throw new ArgumentException("Invalid argument.");
            }
        }
    }
}

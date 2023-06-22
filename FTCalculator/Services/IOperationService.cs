using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.Services
{
    public enum Operator
    {
        Add,
        Subtract,
        Divide,
        Multiply
    }

    public interface IOperationService
    {
        float Add(float valueOne, float valueTwo);
        float Subtract(float valueOne, float valueTwo);
        float Divide(float valueOne, float valueTwo);
        float Mutiply(float valueOne, float valueTwo);
        int Factorial(int value);
    }
}

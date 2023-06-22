using System;

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
    int Factorial(int valueOne, int valueTwo);
}

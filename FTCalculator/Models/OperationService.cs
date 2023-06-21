using System;

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
}

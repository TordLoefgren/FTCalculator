using FTCalculator.Enums;
using System;
using System.Security.RightsManagement;

namespace FTCalculator.Services
{
    /// <summary>
    /// Represents an Operator conversion-service.
    /// </summary>
    public class OperatorConversionService : IOperatorConversionService
    {
        public string OperatorToString(Operator op)
        {
            return op.ToString();
        }

        public Operator StringToOperator(string op)
        {
            return Enum.TryParse(op, out Operator enumOp) ? enumOp : throw new ArgumentException("No such operator exists.");
        }

        public string OperatorToSymbolString(Operator op)
        {
            switch (op)
            {
                case Operator.Add: return " + ";
                case Operator.Subtract: return " - ";
                case Operator.Multiply: return " * ";
                case Operator.Divide: return " / ";
                default: throw new ArgumentException("No such operator exists.");
            }
        }
    }
}

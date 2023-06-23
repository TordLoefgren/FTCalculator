using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTCalculator.Enums
{
    /// <summary>
    /// A static class that performs Operator enum conversions.
    /// </summary>
    public class OperatorConverter
    {
        /// <summary>
        /// Static method that converts an Operator enum to a string.
        /// </summary>
        /// <param name="op">Operator to be converted.</param>
        /// <returns>The string representation of the Operator.</returns>
        /// <exception cref="ArgumentException">No such Operator exists.</exception>
        public static string OperatorToString(Operator op)
        {
            switch (op)
            {
                case Operator.NoOperator:
                    return "NoOperator";
                case Operator.Add:
                    return "Add";
                case Operator.Subtract:
                    return "Subtract";
                case Operator.Multiply:
                    return "Multiply";
                case Operator.Divide:
                    return "Divide";
                case Operator.Factorial:
                    return "Factorial";
                default:
                    throw new ArgumentException("Invalid argument");
            }
        }

        /// <summary>
        /// Static method that converts a string to an Operator enum.
        /// </summary>
        /// <param name="op">String to be converted.</param>
        /// <returns>The Operator representation of the given string.</returns>
        /// <exception cref="ArgumentException">No such Operator exists.</exception>
        public static Operator StringToOperator(string op)
        {
            switch (op)
            {
                case "NoOperator":
                    return Operator.NoOperator;
                case "Add":
                    return Operator.Add;
                case "Subtract":
                    return Operator.Subtract;
                case "Multiply":
                    return Operator.Multiply;
                case "Divide":
                    return Operator.Divide;
                case "Factorial":
                    return Operator.Factorial;
                default:
                    throw new ArgumentException("Invalid argument");
            }
        }
    }
}

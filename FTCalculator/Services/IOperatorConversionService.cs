using FTCalculator.Enums;
using System;

namespace FTCalculator.Services
{
    /// <summary>
    /// Service class that performs Operator conversions.
    /// </summary>
    public interface IOperatorConversionService
    {
        /// <summary>
        /// Method that converts a string to an Operator enum.
        /// </summary>
        /// <param name="op">String to be converted.</param>
        /// <returns>The Operator representation of the given string.</returns>
        /// <exception cref="ArgumentException">No such Operator exists.</exception>
        Operator StringToOperator(string op);

        /// <summary>
        /// Method that converts an Operator enum to a string.
        /// </summary>
        /// <param name="op">Operator to be converted.</param>
        /// <returns>The string representation of the Operator.</returns>
        string OperatorToString(Operator op);

        /// <summary>
        /// Method that converts an Operator enum to its string symbol representation.
        /// </summary>
        /// <param name="op">Operator to be converted.</param>
        /// <returns>The string symbol representation of the Operator.</returns>
        /// /// <exception cref="ArgumentException">No such Operator exists.</exception>
        string OperatorToSymbolString(Operator op);
    }
}

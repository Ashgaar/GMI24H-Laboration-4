using System;

namespace LaborationInterfaces
{
    /// <summary>
    /// Defines a method that calculates a numeric expression in postfix notation.
    /// </summary>
    public interface ILaboration_3_PostfixCalculator
    {
        /// <summary>
        /// Calculates the result of a numeric expression in postfix notation. The substrings handled are:
        /// * Integers (including negative numbers)
        /// * The four basic operators +, -, *, and /
        /// </summary>
        /// <param name="expression">A string, as it has been read from e.g. the Console or a file.</param>
        /// <returns>The result of the calculation.</returns>
        /// <remarks>
        /// The expression must contain space as delimiting character between operands/operators. 
        /// The expression is assumed to be well-formed; if not, any kind of exception may be thrown.
        /// </remarks>
        /// <exception cref="Exception">Any kind of exception may be thrown, if <paramref name="expression"/> is not well-formed.</exception>
        public int Calculate(String expression);
    }
}

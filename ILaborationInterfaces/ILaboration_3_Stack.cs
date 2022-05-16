// VIKTIGT:
//
// I denna labb räcker det att du implementerar _ett_ av interfacen. De har olika svårighetsgrad:
//
// Lättare:  ILaboration_3_StackInt          - Detta interface hanterar alltid integers, och du kan sluta läsa här. :-)
//
//
// Svårare:  ILaboration_3_Stack<TypeName>   - Detta interface är en s.k. "Generic" (sv. generisk) typ,
//                                             som behöver en datatyp som Type Parameter.
//
// Om du väljer att implementera det generiska interfacet, så ska din klass vara generisk:
//
//   public class Laboration_3_Stack<TypeName> : ILaboration_3_Stack<TypeName>
// 

using System;

namespace LaborationInterfaces
{
    /// <summary>
    /// Defines an exception to be used with the stack. 
    /// </summary>
    public class StackEmptyException : Exception
    { }


    //Detta är det ENKLARE interfacet

    /// <summary>
    /// Defines a stack, that holds elements of type <typeparamref name="TypeName"/>. 
    /// </summary>
    public interface ILaboration_3_StackInt
    {
        /// <summary>
        /// Pushes <paramref name="element"/> onto the stack. 
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        public void Push(int element);

        /// <summary>
        /// Returns the uppermost element on the stack, without modifying the stack.
        /// </summary>
        /// <returns>The uppermost element on the stack.</returns>
        /// <exception cref="StackEmptyException">Thrown if method is called when stack is empty.</exception>
        public int Top();

        /// <summary>
        /// Removes the uppermost element on the stack, and returns it.
        /// </summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="StackEmptyException">Thrown if method is called when stack is empty.</exception>
        public int Pop();

        /// <summary>
        /// Removes all elements on the entire stack.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Returns the number of elements on the stack.
        /// </summary>
        /// <returns>The number of elements.</returns>
        public uint Size();
    }


    //Detta är det SVÅRARE interfacet

    /// <summary>
    /// Defines a stack, that holds elements of type <typeparamref name="TypeName"/>. 
    /// </summary>
    /// <typeparam name="TypeName">Type of elements on the stack.</typeparam>
    public interface ILaboration_3_Stack<TypeName>
    {
        /// <summary>
        /// Pushes <paramref name="element"/> onto the stack. 
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        public void Push(TypeName element);

        /// <summary>
        /// Returns the uppermost element on the stack, without modifying the stack.
        /// </summary>
        /// <returns>The uppermost element on the stack.</returns>
        /// <exception cref="StackEmptyException">Thrown if method is called when stack is empty.</exception>
        public TypeName Top();

        /// <summary>
        /// Removes the uppermost element on the stack, and returns it.
        /// </summary>
        /// <returns>The removed element.</returns>
        /// <exception cref="StackEmptyException">Thrown if method is called when stack is empty.</exception>
        public TypeName Pop();

        /// <summary>
        /// Removes all elements on the entire stack.
        /// </summary>
        public void Clear();

        /// <summary>
        /// Returns the number of elements on the stack.
        /// </summary>
        /// <returns>The number of elements.</returns>
        public uint Size();
    }

}

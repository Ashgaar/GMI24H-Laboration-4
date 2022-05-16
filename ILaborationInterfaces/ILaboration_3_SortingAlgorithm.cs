// VIKTIGT:
//
// I denna labb räcker det att du implementerar _ett_ av interfacen. De har olika svårighetsgrad:
//
// Lättare:  ILaboration_3_SortingAlgorithmInt          - Detta interface hanterar alltid integers, och du kan sluta läsa här. :-)
//
//
// Svårare:  ILaboration_3_SortingAlgorithm<TypeName>   - Detta interface är en s.k. "Generic" (sv. generisk) typ,
//                                                        som behöver en datatyp som Type Parameter.
//
// Om du väljer att implementera det generiska interfacet, så ska din klass vara generisk.
//
// Du behöver även specificera att din klass (endast) hanterar typer som implementerar interfacet IComparable.
// Detta för att kunna jämföra typer under sortering.
//
//   public class Laboration_3_AnySort<TypeName> : ILaboration_3_SortingAlgorithm<TypeName> where TypeName : IComparable<TypeName>
// 
// I din Sort()-algoritm jämför du två IComparable med funktionen CompareTo():
//
//   if(var1.CompareTo(var2) == ...)
//
// Följ C#/.NET-dokumentationen vidare, eller ta hjälp av lärare.


namespace LaborationInterfaces
{

    //Detta är det ENKLARE interfacet

    /// <summary>
    /// Defines one method that sorts an array of integers. 
    /// </summary>
    public interface ILaboration_3_SortingAlgorithmInt
    {
        /// <summary>
        /// Sorts the array <paramref name="arr"/>. 
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        public void Sort(int[] arr);
    }

    //Detta är det SVÅRARE interfacet

    /// <summary>
    /// Defines one method that sorts an array of elements, of type <typeparamref name="TypeName"/>. 
    /// </summary>
    /// <typeparam name="TypeName">The type of elements in the array.</typeparam>
    public interface ILaboration_3_SortingAlgorithm<TypeName>
    {
        /// <summary>
        /// Sorts the array <paramref name="arr"/>. 
        /// </summary>
        /// <param name="arr">The array to be sorted.</param>
        public void Sort(TypeName[] arr);
    }
}

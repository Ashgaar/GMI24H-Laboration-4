using System.Collections.Generic;
using LaborationInterfaces;
using Olsson_Mikael;

namespace Lab4_Uppgift_2
{
    public static class WordHandler
    {
        public static ISortedDictionary<string, int> WordsToDictionary(IEnumerable<string> cleanWords)
        {
            ISortedDictionary<string, int> dictionary = new BinarySearchTree<string, int>();
            foreach (var word in cleanWords)
            {
                //Här skriver du din kod. Det är (enbart) denna loop du ska redovisa för laboration 4.
            }

            return dictionary;
        }
    }
}

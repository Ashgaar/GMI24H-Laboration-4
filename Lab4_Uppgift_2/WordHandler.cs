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
                if (dictionary.Contains(word.ToLower()))
                {
                    dictionary.Set(word.ToLower(), dictionary.Get(word.ToLower()) + 1);
                }
                else
                {
                    dictionary.Add(word.ToLower(), 1);
                }
            }

            return dictionary;
        }
    }
}

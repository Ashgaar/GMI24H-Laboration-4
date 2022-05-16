using System;
using System.IO;
using LaborationInterfaces;
using Olsson_Mikael;

namespace Uppgift01
{
    class Program
    {
        static void Main(string[] args)
        {
            ISortedDictionary<string, int> myMapp = new BinarySearchTree<string, int>();
            Console.WriteLine($"Antal poster innan någonting är inlagt: {myMapp.Count}");

            myMapp.Add("D", 1);
            myMapp.Add("B", 2);
            myMapp.Add("F", 3);
            myMapp.Add("A", 4);
            myMapp.Add("C", 5);
            myMapp.Add("E", 6);
            myMapp.Add("G", 7);

            Console.WriteLine($"Antal poster efter att 6 poster har lagts in: {myMapp.Count}");

            // myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));

            // Fortsätt med lämplig kod för att kontrollera att allt fungerar... .
            
            Console.WriteLine("\nTryck på Enter för att avsluta.");
            Console.ReadLine();
        }
    }
}

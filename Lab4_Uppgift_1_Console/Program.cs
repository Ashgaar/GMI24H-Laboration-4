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
            Console.WriteLine("Adding D to list");
            //myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            myMapp.Add("B", 2);
            Console.WriteLine("Adding B to list");
            //myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            myMapp.Add("F", 3);
            Console.WriteLine("Adding F to list");
            //myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            myMapp.Add("A", 4);
            Console.WriteLine("Adding A to list");
            //myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            myMapp.Add("C", 5);
            Console.WriteLine("Adding C to list");
            //myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            myMapp.Add("E", 6);
            Console.WriteLine("Adding E to list");
            //myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            myMapp.Add("G", 7);
            Console.WriteLine("Adding E to list");
            myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));
            
            Console.WriteLine($"Antal poster efter att 7 poster har lagts in: {myMapp.Count}");

            myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));

            myMapp.Remove("A");

            Console.WriteLine($"Antal poster efter att någon har tagits bort: {myMapp.Count}");
            myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));

            Console.WriteLine($"Looking for D: {myMapp.Contains("D")}");

            Console.WriteLine($"The value of C: {myMapp.Get("C")}");
            myMapp.Set("E", 10);
            Console.WriteLine($"E after setting it to 10: {myMapp.Get("E")}");
            Console.WriteLine($"Count: {myMapp.Count}");
            myMapp.Traverse(x => Console.WriteLine($"Nyckel: {x.Key} Värde: {x.Value}"));


            //produces error correctly
            //myMapp.Remove("A");

            Console.WriteLine("\nTryck på Enter för att avsluta.");
            Console.ReadLine();
        }
    }
}

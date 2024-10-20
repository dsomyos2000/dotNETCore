using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<string> fruits = new List<string>() { "Apple", "Banana", "Orange" };

        // Get the enumerator for the List<string>
        IEnumerator<string> enumerator = fruits.GetEnumerator();

        // Iterate through the collection using the enumerator
        while (enumerator.MoveNext())
        {
            string fruit = enumerator.Current;
            Console.WriteLine(fruit);
        }

        // Dispose the enumerator
        enumerator.Dispose();
    }
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

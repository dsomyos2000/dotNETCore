using System;
using System.Collections;

public class Program
{
    public static void Main()
    {
        // Create a collection of integers
        int[] numbers = { 1, 2, 3, 4, 5 };
        IEnumerable<int> IEnumbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        IEnumerable<string> names = new List<string> { "John", "Jane", "Alice" };
        int[] array = IEnumbers.ToArray();
        string[] nameArray = names.ToArray();

        // Use IEnumerable to iterate over the collection
        IEnumerable enumerable = numbers;

        // Get the enumerator
        IEnumerator enumerator = enumerable.GetEnumerator();

        // Iterate over the collection using the enumerator
        while (enumerator.MoveNext())
        {
            int number = (int)enumerator.Current;
            Console.WriteLine(number);
        }
        Console.WriteLine($"numbers.Sum()={numbers.Sum()}");
        Console.WriteLine($"IEnumbers.Sum()={IEnumbers.Sum()}");
    }
}



// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

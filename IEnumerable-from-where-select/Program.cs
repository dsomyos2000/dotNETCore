using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        // Create a list of integers
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        // Use IEnumerable with from, where, and select clauses
        IEnumerable<int> evenNumbers = from num in numbers
                                       where num % 2 == 0
                                       select num;
        // Print the even numbers
        foreach (int num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var numbers = new List<int> { 10, 11, 12 };
        // Call TrueForAll to ensure a condition is true.
        if (numbers.TrueForAll(element => element < 20))
        {
            Console.WriteLine("All elements less than 20");
        }
    }
}
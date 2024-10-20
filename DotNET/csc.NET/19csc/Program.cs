using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var numbers = new List<int> { 10, 20, 30 };
        var numbers2 = new List<int> { 10, 20, 30 };
        // See if the two lists are equal.
        if (numbers.SequenceEqual(numbers2))
        {
            Console.WriteLine("LISTS ARE EQUAL");
        }
    }
}

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Version 1: create a List of ints.
        // ... Add 4 ints to it.
        var numbers = new List<int>();
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(5);
        numbers.Add(7);
        Console.WriteLine("LIST 1: " + numbers.Count);
        
        // Version 2: create a List with an initializer.
        var numbers2 = new List<int>() { 2, 3, 5, 7 };
        Console.WriteLine("LIST 2: " + numbers2.Count);
    }
}
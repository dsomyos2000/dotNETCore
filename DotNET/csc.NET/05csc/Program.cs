using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a list of 2 strings.
        var animals = new List<string>() { "bird", "dog" };
        // Insert strings from an array in position 1.
        animals.InsertRange(1, new string[] { "frog", "snake" });
        foreach (string value in animals)
        {
            Console.WriteLine("RESULT: " + value);
        }
    }
}
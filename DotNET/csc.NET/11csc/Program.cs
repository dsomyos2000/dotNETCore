using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var animals = new List<string>() { "bird", "dog" };
        // Use ForEach with a lambda action.
        // ... Write each string to the console.
        animals.ForEach(a => Console.WriteLine("ANIMAL: " + a));
    }
}
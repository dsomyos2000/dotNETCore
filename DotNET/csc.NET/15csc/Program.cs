using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Part 1: call add to populate list.
        List<string> dogs = new List<string>();
        dogs.Add("spaniel"); // Contains: spaniel.
        dogs.Add("beagle"); // Contains: spaniel, beagle.
        
        // Part 2: insert element in second position.
        dogs.Insert(1, "dalmatian");
        foreach (string dog in dogs)
        {
            Console.WriteLine(dog);
        }
    }
}
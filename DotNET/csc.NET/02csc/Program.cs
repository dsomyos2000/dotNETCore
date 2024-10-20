using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> list = new List<int>() { 2, 3, 7 };
        
        // Part A: loop through List with foreach.
        foreach (int prime in list)
        {
            // Part B: access each element with name.
            System.Console.WriteLine("PRIME ELEMENT: {0}", prime);
        }
    }
}
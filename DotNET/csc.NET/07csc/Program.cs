using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create new array with 3 elements.
        int[] array = new int[] { 2, 3, 5 };
        
        // Copy the array to a List.
        List<int> copied = new List<int>(array);
        
        // Print size of List.
        Console.WriteLine("COPIED COUNT: {0}", copied.Count);
    }
}
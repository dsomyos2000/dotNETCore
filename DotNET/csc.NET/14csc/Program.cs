using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Populate example Dictionary.
        var dict = new Dictionary<int, bool>();
        dict.Add(3, true);
        dict.Add(5, false);
        
        // Get a List of all the Keys.
        List<int> keys = new List<int>(dict.Keys);
        foreach (int key in keys)
        {
            Console.WriteLine(key);
        }
    }
}
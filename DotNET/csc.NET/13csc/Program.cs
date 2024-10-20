using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // List of cities we need to join.
        List<string> cities = new List<string>();
        cities.Add("New York");
        cities.Add("Mumbai");
        cities.Add("Berlin");
        cities.Add("Istanbul");
        
        // Join strings into one CSV line.
        string line = string.Join(",", cities.ToArray());
        Console.WriteLine(line);
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Part A: build up List, and Count its elements.
        List<bool> list = new List<bool>();
        list.Add(true);
        list.Add(false);
        list.Add(true);
        Console.WriteLine(list.Count);
        
        // Part B: call Clear() on List.
        list.Clear();
        Console.WriteLine(list.Count);
    }
}
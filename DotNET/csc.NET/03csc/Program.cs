using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Part 1: create List.
        // ... Print the first element of the List.
        List<int> list = new List<int>(new int[]{ 2, 3, 7 });
        Console.WriteLine("FIRST ELEMENT: {0}",list[0]);
        
        // Part 2: loop with for and access count.
        for (int i = 0; i < list.Count; i++)
        {
            // Part 3: access element with index.
            Console.WriteLine("{0} = {1}",i,list[i]);
        }
    }
}
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> rivers = new List<string>(new string[]
        {
            "nile",
            "amazon", // River 2.
            "yangtze", // River 3.
            "mississippi",
            "yellow"
        });
        
        // Get rivers 2 through 3.
        List<string> range = rivers.GetRange(1, 2);
        foreach (string river in range)
        {
            Console.WriteLine(river);
        }
    }
}
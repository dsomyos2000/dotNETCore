using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var votes = new List<bool> { false, false, true };
        
        // Loop through votes in reverse order.
        for (int i = votes.Count - 1; i >= 0; i--)
        {
            Console.WriteLine("DECREMENT LIST LOOP: {0}", votes[i]);
        }
    }
}
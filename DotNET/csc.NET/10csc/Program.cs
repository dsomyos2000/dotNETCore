using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var values = new List<int>();
        values.Add(1);
        values.Add(2);
        values.Add(3);
        
        // The Contains method can be called with any possible value.
        if (values.Contains(3))
        {
            Console.WriteLine("Contains 3");
        }
    }
}
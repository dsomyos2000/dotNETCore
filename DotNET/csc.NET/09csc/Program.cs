using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var primes = new List<int>(new int[] { 19, 23, 29 });
        
        int index = primes.IndexOf(23); // Exists.
        Console.WriteLine(index);
        
        index = primes.IndexOf(10); // Does not exist.
        Console.WriteLine(index);
    }
}
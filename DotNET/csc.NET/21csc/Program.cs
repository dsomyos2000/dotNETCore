using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    const int _max = 1000000;
    static void Main()
    {
        // Version 1: create string array with 3 elements in it.
        var s1 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            var items = new string[] { "bird", "frog", "fish" };
            if (items.Length == 0)
            {
                return;
            }
        }
        s1.Stop();
        // Version 2: create string list with 3 elements in it.
        var s2 = Stopwatch.StartNew();
        for (int i = 0; i < _max; i++)
        {
            var items = new List<string>() { "bird", "frog", "fish" };
            if (items.Count == 0)
            {
                return;
            }
        }
        s2.Stop();
        Console.WriteLine(((double)(s1.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
        Console.WriteLine(((double)(s2.Elapsed.TotalMilliseconds * 1000000) / _max).ToString("0.00 ns"));
    }
}
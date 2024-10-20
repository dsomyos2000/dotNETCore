using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> list = new List<string>();
        list.Add("anchovy");
        list.Add("barracuda");
        list.Add("bass");
        list.Add("viperfish");
        
        // Reverse List in-place, no new variables required.
        list.Reverse();
        
        foreach (string value in list)
        {
            Console.WriteLine(value);
        }
    }
}
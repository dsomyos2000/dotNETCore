using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var values = new List<int>() { 200, 300, 500 };
        
        // Pass list the method.
        if (ContainsValue300(values))
        {
            Console.WriteLine("RETURNED TRUE");
        }
    }
    
    static bool ContainsValue300(List<int> list)
    {
        foreach (int number in list)
        {
            // See if the element in the list equals 300.
            if (number == 300)
            {
                return true;
            }
        }
        // No return was reached, so nothing matched.
        return false;
    }
}
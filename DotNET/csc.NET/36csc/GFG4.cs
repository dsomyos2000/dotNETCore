// C# program to create 3-tuple
// using create method
using System;

public class GFG4 {

	// Main method
	static public void Main()
	{

		// Creating tuple with three
		// elements using Create method
		var My_Tuple = Tuple.Create("Geeks", 20, 'f');

		Console.WriteLine("Element 1: " + My_Tuple.Item1);
		Console.WriteLine("Element 2: " + My_Tuple.Item2);
		Console.WriteLine("Element 3: {0}", My_Tuple.Item3);
	}
}

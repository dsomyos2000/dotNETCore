// C# program to create 2-tuple
// using create method
using System;

public class GFG3 {

	// Main method
	static public void Main()
	{

		// Creating tuple with two elements
		// Using Create method
		var My_Tuple = Tuple.Create("Geeks", 20);

		Console.WriteLine("Element 1: " + My_Tuple.Item1);
		Console.WriteLine("Element 2: " + My_Tuple.Item2);
	}
}

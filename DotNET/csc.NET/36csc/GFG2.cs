// C# program to create 1-tuple
// using create method
using System;

public class GFG2 {

	// Main method
	static public void Main()
	{

		// Creating tuple with one elements
		// Using Create method
		var My_Tuple = Tuple.Create("Geeks");

		Console.WriteLine("Element: " + My_Tuple.Item1);
	}
}

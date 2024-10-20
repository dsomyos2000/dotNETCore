// C# program to create tuple
// using tuple constructor.
using System;

class GFG {

	// Main method
	static public void Main()
	{

		// Creating tuple with seven elements
		// Using Tuple<T1, T2, T3, T4, T5, T6,
		// T7>(T1, T2, T3, T4, T5, T6, T7) constructor
		Tuple<int, int, int, int, int, int, int> My_Tuple = new Tuple<int,
			int, int, int, int, int, int>(22, 334, 54, 65, 76, 87, 98);

		Console.WriteLine("Element 1: " + My_Tuple.Item1);
		Console.WriteLine("Element 2: " + My_Tuple.Item2);
		Console.WriteLine("Element 3: " + My_Tuple.Item3);
		Console.WriteLine("Element 4: " + My_Tuple.Item4);
		Console.WriteLine("Element 5: " + My_Tuple.Item5);
		Console.WriteLine("Element 6: " + My_Tuple.Item6);
		Console.WriteLine("Element 7: " + My_Tuple.Item7);
	}
}

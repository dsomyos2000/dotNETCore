// C# program to create tuple
// using Create Method
using System;

public class GFG5 {

	// Main method
	static public void Main()
	{

		// Creating 1-tuple
		// Using Create Method
		var My_Tuple1 = Tuple.Create("GeeksforGeeks");
                var T2 = Tuple.Create(10,"ELEVEN");

		// Creating 4-tuple
		// Using Create Method
		var My_Tuple2 = Tuple.Create(12, 30, 40, 50);

		// Creating 8-tuple
		// Using Create Method
		var T3 = Tuple.Create(13, "Geeks", 67, 89.90, 'g', 39939, "geek", Tuple.Create(12, 30, 40, 50));
		Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}",T3.Item1,T3.Item2,T3.Item3,T3.Item4,T3.Item5,T3.Item6,T3.Item7,T3.Rest);
		Console.WriteLine("Element of Nested tuple: "+ T3.Rest.Item1.Item1);
		Console.WriteLine("Element of Nested tuple: "+ T3.Rest.Item1.Item2);
		Console.WriteLine("Element of Nested tuple: "+ T3.Rest.Item1.Item3);
		Console.WriteLine("Element of Nested tuple: "+ T3.Rest.Item1.Item4);
	}
}

// C# program to illustrate
// how a method return tuple
using System;

public class Program {
	
		// Main Method
	static public void Main ()
		{
			// Return tuple is stored in mytuple
		var mytuple = PrintTuple();
		Console.WriteLine(mytuple.Item1);
		Console.WriteLine(mytuple.Item2);
		Console.WriteLine(mytuple.Item3);
	}
	
	// PrintTuple method return a tuple
	static Tuple<string, string, string> PrintTuple() {
		return Tuple.Create("Geeks", "For", "Geeks");
	}
}

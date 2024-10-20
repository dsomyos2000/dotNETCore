// C# program to illustrate nested tuple
using System;

public class Program {
	
		// Main method
	static public void Main ()
		{
		
		// Nested Tuple
		// Here nested tuple is present
			// at the place of 2nd element
		var My_Tuple = Tuple.Create(13, Tuple.Create(12, 30, 40,
							50),67, 89.90, 'g', 39939, 123, "geeks");
		
		// Accessing the element of Tuple
		// Using Item property
		// And accessing the elements of
		// nested tuple Using Rest property
		Console.WriteLine("Element of My_Tuple: {0} - .Item1",My_Tuple.Item1);
		Console.WriteLine("Element of Nested Tuple: {0} - .Item2.Item1",My_Tuple.Item2.Item1);
		Console.WriteLine("Element of Nested Tuple: {0} - .Item2.Item2",My_Tuple.Item2.Item2);
		Console.WriteLine("Element of Nested Tuple: "+My_Tuple.Item2.Item3);
		Console.WriteLine("Element of Nested Tuple: "+My_Tuple.Item2.Item4);
		Console.WriteLine("Element of My_Tuple: {0} - .Item3",My_Tuple.Item3);
		Console.WriteLine("Element of My_Tuple: "+My_Tuple.Item4);
		Console.WriteLine("Element of My_Tuple: "+My_Tuple.Item5);
		Console.WriteLine("Element of My_Tuple: "+My_Tuple.Item6);
		Console.WriteLine("Element of My_Tuple: "+My_Tuple.Item7);
		Console.WriteLine("Element of My_Tuple: "+My_Tuple.Rest);
		
	}
}

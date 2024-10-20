// C# program to illustrate how to
// access the element of ValueTuple<T1,
// T2, T3, T4, T5, T6, T7, TRest>
using System;

class Program {

	// Main Method
	static public void Main()
	{

		// Creating a value tuple
		// Using Create method
		var Mylibrary = ValueTuple.Create(3456, "The Guide", "R. K. Narayan",
							1958, "Philosophical novel", "English", "India",
					ValueTuple.Create("Swami and Friends", "The Dark Room",
									"Mr. Sampath", "Grandmother's Tale"));

		// Display the element of the given value tuple
		Console.WriteLine("Book Details: ");
		Console.WriteLine("Book Id: {0}", Mylibrary.Item1);
		Console.WriteLine("Book Name: {0}", Mylibrary.Item2);
		Console.WriteLine("Author Name: {0}", Mylibrary.Item3);
		Console.WriteLine("Publication date: {0}", Mylibrary.Item4);
		Console.WriteLine("Gener: {0}", Mylibrary.Item5);
		Console.WriteLine("Language: {0}", Mylibrary.Item6);
		Console.WriteLine("Country: {0}", Mylibrary.Item7);
		Console.WriteLine("Other Novels: {0}", Mylibrary.Rest);
	}
}

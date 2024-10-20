// C# code to get the number of
// key/values pairs contained
// in the OrderedDictionary
using System;
using System.Collections;
using System.Collections.Specialized;

class GFG3 {

	// Driver method
	public static void Main()
	{

		// Creating a orderedDictionary named myDict
		OrderedDictionary myDict = new OrderedDictionary();

		// Adding key and value in myDict
		myDict.Add("A", "Apple");
		myDict.Add("B", "Banana");
		myDict.Add("C", "Cat");
		myDict.Add("D", "Dog");

		// To Get the number of key/values
		// pairs contained in the OrderedDictionary
		Console.WriteLine("Number of key/value pairs are : "+ myDict.Count);
	}
}

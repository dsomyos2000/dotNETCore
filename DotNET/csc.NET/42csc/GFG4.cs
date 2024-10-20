// C# code to get a read-only
// copy of the OrderedDictionary
using System;
using System.Collections;
using System.Collections.Specialized;

class GFG4 {

	// Driver method
	public static void Main()
	{

		// Creating a orderedDictionary named myDict
		OrderedDictionary myDict = new OrderedDictionary();

		// Adding key and value in myDict
		myDict.Add("key1", "value1");
		myDict.Add("key2", "value2");
		myDict.Add("key3", "value3");
		myDict.Add("key4", "value4");
		myDict.Add("key5", "value5");

		// To Get a read-only copy of
		// the OrderedDictionary
		OrderedDictionary myDict_1 = myDict.AsReadOnly();

		// Checking if myDict_1 is read-only
		Console.WriteLine(myDict_1.IsReadOnly);
	}
}

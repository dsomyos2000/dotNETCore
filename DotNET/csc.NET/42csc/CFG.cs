// C# code to create a OrderedDictionary
using System;
using System.Collections;
using System.Collections.Specialized;

class GFG {

	// Driver method
	public static void Main()
	{

		// Creating a orderedDictionary named myDict
		OrderedDictionary myDict = new OrderedDictionary();

		// Adding key and value in myDict
		myDict.Add("1", "ONE");
		myDict.Add("2", "TWO");
		myDict.Add("3", "THREE");

		// Displaying the number of key/value
		// pairs in myDict
		Console.WriteLine(myDict.Count);

		// Displaying the key/value pairs in myDict
		foreach(DictionaryEntry de in myDict)
			Console.WriteLine(de.Key + " --> " + de.Value);
	}
}

// C# code to remove the entry
// with the specified key from
// the OrderedDictionary
using System;
using System.Collections;
using System.Collections.Specialized;

class GFG5 {

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

		// Displaying the number of element initially
		Console.WriteLine("Number of elements are : " + myDict.Count);

		// Displaying the elements in myDict
		foreach(DictionaryEntry de in myDict)
			Console.WriteLine(de.Key + " -- " + de.Value);

		// Removing the entry with the specified
		// key from the OrderedDictionary
		myDict.Remove("key2");

		// Displaying the number of element initially
		Console.WriteLine("Number of elements are : " + myDict.Count);

		// Displaying the elements in myDict
		foreach(DictionaryEntry de in myDict)
			Console.WriteLine(de.Key + " -- " + de.Value);
	}
}

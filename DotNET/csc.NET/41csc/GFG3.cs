// C# code to do bitwise
// OR between BitArray
using System;
using System.Collections;

class GFG3 {

	// Driver code
	public static void Main()
	{

		// Creating a BitArray
		BitArray myBitArr1 = new BitArray(4);

		// Creating a BitArray
		BitArray myBitArr2 = new BitArray(4);

		// Initializing values in myBitArr1
		myBitArr1[0] = false;
		myBitArr1[1] = false;
		myBitArr1[2] = true;
		myBitArr1[3] = true;

		// Initializing values in myBitArr2
		myBitArr2[0] = false;
		myBitArr2[1] = true;
		myBitArr2[2] = false;
		myBitArr2[3] = true;

		// function calling
		PrintValues(myBitArr1.Or(myBitArr2));
	}

	// Displaying the result
	public static void PrintValues(IEnumerable myList)
	{
		foreach(Object obj in myList)
		{
			Console.WriteLine(obj);
		}
	}
}

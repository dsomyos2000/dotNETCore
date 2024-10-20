// C# code to create a BitArray
using System;
using System.Collections;

class GFG {

	// Driver code
	public static void Main()
	{

		// Creating a BitArray
		BitArray myBitArr = new BitArray(5);

		myBitArr[0] = true;
		myBitArr[1] = true;
		myBitArr[2] = false;
		myBitArr[3] = true;
		myBitArr[4] = false;

		Console.WriteLine("{0}|{1}|{2}|{3}|{4}",myBitArr.Get(0),myBitArr.Get(1),myBitArr.Get(2),myBitArr.Get(3),myBitArr.Get(4));
		// To get the value of index at index 2
		Console.WriteLine(myBitArr.Get(2));

		// To get the value of index at index 3
		Console.WriteLine(myBitArr.Get(3));
	}
}

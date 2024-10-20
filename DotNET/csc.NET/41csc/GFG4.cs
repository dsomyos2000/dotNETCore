// C# code to set all bits in the
// BitArray to the specified value
using System;
using System.Collections;

class GFG4 {

	// Driver code
	public static void Main()
	{

		// Creating a BitArray myBitArr
		BitArray myBitArr = new BitArray(5);

		// Initializing all the bits in myBitArr
		myBitArr[0] = false;
		myBitArr[1] = true;
		myBitArr[2] = true;
		myBitArr[3] = false;
		myBitArr[4] = true;

		// Printing the values in myBitArr
		Console.WriteLine("Initially the bits are as : ");

		PrintIndexAndValues(myBitArr);

		// Setting all bits to false
		myBitArr.SetAll(false);

		// Printing the values in myBitArr
		// It should display all the bits as false
		Console.WriteLine("Finally the bits are as : ");

		PrintIndexAndValues(myBitArr);
	}

	// Function to display bits
	public static void PrintIndexAndValues(IEnumerable myArr)
	{
		foreach(Object obj in myArr)
		{
			Console.WriteLine(obj);
		}
	}
}

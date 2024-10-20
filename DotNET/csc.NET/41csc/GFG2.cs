// C# program to illustrate the
// BitArray Class Properties
using System;
using System.Collections;

class GFG2 {
	
	// Driver code
	public static void Main()
	{
	
		// Creating a BitArray
		BitArray myBitArr = new BitArray(new byte[] { 0, 0, 0, 1 });
	
		// -------- IsReadOnly Property --------
		
		// Checking if the BitArray is read-only
		Console.WriteLine(myBitArr.IsReadOnly);
		
		// -------- Count Property --------
		
		// To get the number of elements
		// contained in the BitArray
		Console.WriteLine(".Count => {0}",myBitArr.Count);
	}
}

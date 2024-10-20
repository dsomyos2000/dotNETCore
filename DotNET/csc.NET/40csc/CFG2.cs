// C# program to illustrate how
// to check element present in
// the stack or not
using System;
using System.Collections;

class GFG2 {

	// Main Method
	static public void Main()
	{

		// Create a stack
		// Using Stack class
		Stack my_stack = new Stack();

		// Adding elements in the Stack
		// Using Push method
		my_stack.Push("Geeks");
		my_stack.Push("geeksforgeeks");
		my_stack.Push("geeks23");
		my_stack.Push("GeeksforGeeks");

		// Checking if the element is
		// present in the Stack or not
		if (my_stack.Contains("GeeksforGeeks") == true)
		{
			Console.WriteLine("Element is found...!!");
		}

		else
		{
			Console.WriteLine("Element is not found...!!");
		}
	}
}

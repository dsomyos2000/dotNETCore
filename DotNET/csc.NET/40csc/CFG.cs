// C# program to illustrate how to
// get topmost elements of the stack
using System;
using System.Collections;

class GFG {

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

		Console.WriteLine("Total elements present in"+
					" my_stack: {0}",my_stack.Count);
													
		// Obtain the topmost element
		// of my_stack Using Pop method
		Console.WriteLine("Topmost element of my_stack"
						+ " is: {0}",my_stack.Pop());
						
		Console.WriteLine("Total elements present in"+
					" my_stack: {0}", my_stack.Count);
						
		// Obtain the topmost element
		// of my_stack Using Peek method
		Console.WriteLine("Topmost element of my_stack "+
							"is: {0}",my_stack.Peek());
						

		Console.WriteLine("Total elements present "+
				"in my_stack: {0}",my_stack.Count);
						
	}
}

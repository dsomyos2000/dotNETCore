// C# program to illustrate how an
// anonymous function access variable
// defined in outer method
using System;

class GFG2 {

	// Create a delegate
	public delegate void petanim(string pet);

	// Main method
	static public void Main()
	{

		string fav = "Rabbit";

		// Anonymous method with one parameter
		petanim p = delegate(string mypet)
		{
			Console.WriteLine("My favorite pet is {0}.",
												mypet);

			// Accessing variable defined
			// outside the anonymous function
			Console.WriteLine("And I like {0} also.", fav);
		};
		p("Dog");
	}
}

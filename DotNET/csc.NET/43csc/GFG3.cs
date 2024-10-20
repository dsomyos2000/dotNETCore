// C# program to illustrate how an
// anonymous method passed as a parameter
using System;

public delegate void Show(string x);

class GFG3 {

	// identity method with two parameters
	public static void identity(Show mypet,
							string color)
	{
		color = " Black" + color;
		mypet(color);
	}

	// Main method
	static public void Main()
	{

		// Here anonymous method pass as
		// a parameter in identity method
		identity(delegate(string color) {
		Console.WriteLine("The color"+
		" of my dog is {0}", color); },
								"White");
	}
}

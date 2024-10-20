public partial class Circle {

	public void newarea(int a)
	{
		area(int a);
	}

	// This is the definition of
	// partial method
	partial void area(int r)
	{
		int A = 3.14 * r * r;
		Console.WriteLine("Area is : {0}", A);
	}
}

public class Circle {

	public void Display()
	{
		Console.WriteLine("Example of partial method");
	}

	public void newarea(int a)
	{
		area(int a);
	}

	private void area(int r)
	{
		int A = 3.14 * r * r;
		Console.WriteLine("Area is : {0}", A);
	}
}

using System;
using System.Runtime.InteropServices;

class Program
{
	[DllImport("Kernel32.dll")]
	public static extern bool SetConsoleTitle(string strMessage);

	static void Main()
	{
		Console.WriteLine("Start");
		SetConsoleTitle("C# Programming");
		Console.ReadLine();
	}
}
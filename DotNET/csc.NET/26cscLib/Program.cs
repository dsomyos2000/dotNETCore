using System;
using MathLibrary;

namespace MathDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Plz Enter Your Number 1:");
            var num1 = Console.ReadLine();
            int var1 = Convert.ToInt32(num1);

            Console.WriteLine("Plz Enter Your Number 2:");
            var num2 = Console.ReadLine();
            int var2 = Convert.ToInt32(num2);

            Console.WriteLine("Enter  a new operator (Addition/Subtraction/Multiplication/Division/Modulo)");
            var operation = Console.ReadLine();

            MathOperation mathOperation = new MathOperation();
            double data = mathOperation.Perform(var1, var2, operation);

            Console.WriteLine("The Result is : {0}", data);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);

        }
    }
}
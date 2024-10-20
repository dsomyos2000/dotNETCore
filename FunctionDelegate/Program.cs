using System;
using System.Collections;
using System.Collections.Generic;

namespace nsMyFunctionDelegate {
    class Program {
        public delegate int MyFunctionDelegate(int a, int b);
        public static void Main() {
            Program prog = new Program();
            prog.MyMethod(Program.Add);
            prog.MyMethod((a,b) => a + b);
            prog.MyMethod((a,b) => a * b);
            prog.MyMethod((a,b) => a - b);
            prog.MyMethod((a,b) => a % b);
            prog.MyMethod(Program.Pow);
        }
        public static int Add(int a, int b)
        {
            return a + b;
        }
        public static int Pow(int a, int b)
        {
            return (int)Math.Pow(a, b);
        }
        public void MyMethod(MyFunctionDelegate function)
        {
            // Call the function parameter
            int result = function(5, 2);
            
            // Do something with the result
            var opr = "Unknown";
            if (function.Method.Name == "Add") {
                opr = "`Add`";
            } else if (function.Method.Name == "Pow") {
                opr = "`Math.Pow`";
            } else if (result == 7) {
                opr = "+";
            } else if (result == 3) {
                opr = "-";
            } else if (result == 10) {
                opr = "*";
            } else if (result == 1) {
                opr = "%";
            }
            //Console.WriteLine($"result=`{result}`, {function.Method.Name}, result == 8:{result == 8}, result == 15:{result == 15}; {5 % 2}");
            Console.WriteLine($"[5 {opr} 2]: The result {opr} is: {result}");
        }
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;  
using SampleLibrary;  
public class Exercise  
{  
    static void Main()  
    {  
        Algebra alg = new Algebra();  
        double number1 = 100;  
        double number2 = 50;  
        double result = alg.Addition(number1, number2);  
        Console.WriteLine("{0} + {1} = {2}",number1,number2,result);  
        Console.WriteLine("{0} - {1} = {2}",number1,number2,alg.Subtraction(number1, number2));  
        Console.WriteLine("{0} * {1} = {2}",number1,number2,alg.Multiplication(number1, number2));  
        Console.WriteLine("{0} / {1} = {2}",number1,number2,alg.Division(number1, number2));  
    }  
}
using System;

namespace MathLibrary
{
    public class MathOperation
    {

        public double Perform(double n1, double n2, string operation)
        {
            double data = 0;
            switch(operation)
            {
                case "Addition":
                    data = n1 + n2;
                    break;
                case "Subtraction":
                    data = n1 - n2;
                    break;
                case "Multiplication":
                    data = n1 * n2;
                    break;
                case "Division":
                    data = (double)n1 / n2;
                    break;
                case "Modulo":
                    data = n1 % n2;
                    break;
                default:
                    Console.WriteLine("Plz you check your some operatiom");
                    break;
            }
            return data;
        }
    }
}
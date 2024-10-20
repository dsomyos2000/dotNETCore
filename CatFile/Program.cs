// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //string filePath = @"C:\tmp\test1ps.txt";
        string filePath = @"C:\tmp\Book1.csv";

        using (StreamReader reader = new StreamReader(filePath))
        {
            string fileContent = reader.ReadToEnd();
            Console.WriteLine(fileContent);
        }
    }
}

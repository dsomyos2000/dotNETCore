// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            WebClient client = new WebClient();
            string rawContent = client.DownloadString("http://localhost:8080/end");
            Console.WriteLine(rawContent);
        }
        catch (Exception ex)
        {
            // Handle any exceptions here
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

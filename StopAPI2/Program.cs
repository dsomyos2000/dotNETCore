// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Http;

class Program
{
    static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        string url = "http://localhost:8080/end";
        
        try
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            response.EnsureSuccessStatusCode();
            
            // Process the response here
            
            Console.WriteLine("Request successful");
        }
        catch (Exception ex)
        {
            // Handle any exceptions here
            
            Console.WriteLine("Request failed: " + ex.Message);
        }
    }
}

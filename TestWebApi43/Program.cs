// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Net.Http;

class Program
{
    static async System.Threading.Tasks.Task Main(string[] args)
    {
        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync("http://10.81.1.43:8080/api/values");
        string content = await response.Content.ReadAsStringAsync();
        Console.WriteLine(content);
    }
}

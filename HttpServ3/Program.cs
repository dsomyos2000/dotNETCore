using System;
using System.Net;
using System.Threading.Tasks;

public class Program
{
    static async Task Main(string[] args)
    {
        const string listenurl = "http://localhost:8087/";
        var listener = new HttpListener();
        listener.Prefixes.Add(listenurl); // Set the URL prefix to listen on

        listener.Start(); // Start the listener

        Console.WriteLine($"{listenurl}\nListening for requests...");

        while (true)
        {
            var context = await listener.GetContextAsync(); // Wait for an incoming request

            // Handle the request in a separate task
            Task.Run(() => HandleRequest(context));
        }
    }

    static void HandleRequest(HttpListenerContext context)
    {
        var request = context.Request;
        var response = context.Response;

        // Process the request and generate a response
        var responseData = "Hello, World!";
        var buffer = System.Text.Encoding.UTF8.GetBytes(responseData);

        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);
        response.OutputStream.Close();
    }
}

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Net;
using System.Text;

using var listener = new HttpListener();
listener.Prefixes.Add("http://localhost:8800/");

listener.Start();

Console.WriteLine("Listening on port 8800...");

while (true)
{
    HttpListenerContext ctx = listener.GetContext();
    using HttpListenerResponse resp = ctx.Response;
    HttpListenerRequest   req   = ctx.Request;

    Console.WriteLine($"Received request for {req.Url}");

    resp.Headers.Set("Content-Type", "text/plain");

    resp.StatusCode = (int) HttpStatusCode.OK;
    resp.StatusDescription = "Status OK";

    string data = "Hello there!";
    byte[] buffer = Encoding.UTF8.GetBytes(data);
    resp.ContentLength64 = buffer.Length;

    using Stream ros = resp.OutputStream;
    ros.Write(buffer, 0, buffer.Length);
}
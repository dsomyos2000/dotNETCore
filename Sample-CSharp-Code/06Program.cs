//##https://riptutorial.com/dot-net/topic/9059/-net-core
//Search: 'example for RESTFul Listener c# code' in ChatGPT AI
using System;
using System.Net;
using System.IO;
using System.Text;

namespace RestfulListenerExample
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();
            Console.WriteLine("Listening...");

            while (true)
            {
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;

                Console.WriteLine("{0} {1} HTTP/1.1", request.HttpMethod, request.Url);

                string responseString = "<html><body><h1>Hello, World!</h1></body></html>";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);

                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
            }
        }
    }
}

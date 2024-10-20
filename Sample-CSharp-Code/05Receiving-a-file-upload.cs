//##https://csharp.hotexamples.com/examples/System.Net/HttpListener/-/php-httplistener-class-examples.html
using System;
using System.Net;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://localhost:8080/");
        listener.Start();
        Console.WriteLine("Listening for requests on http://localhost:8080/");

        while (true)
        {
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;

            if (request.HttpMethod == "POST" && request.ContentType.StartsWith("multipart/form-data"))
            {
                string filename = "";

                foreach (string header in request.Headers)
                {
                    if (header.StartsWith("Content-Disposition"))
                    {
                        int startIndex = header.IndexOf("filename=") + 10;
                        int endIndex = header.LastIndexOf("\"");
                        filename = header.Substring(startIndex, endIndex - startIndex);
                        filename = Path.GetFileName(filename);
                    }
                }

                byte[] buffer = new byte[request.ContentLength64];
                int bytesRead = request.InputStream.Read(buffer, 0, buffer.Length);

                using (FileStream fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buffer, 0, bytesRead);
                }

                HttpListenerResponse response = context.Response;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.StatusDescription = "OK";
                response.Close();
            }
            else
            {
                HttpListenerResponse response = context.Response;
                response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                response.StatusDescription = "Method Not Allowed";
                response.Close();
            }
        }
    }
}
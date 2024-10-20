using System;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;

class Program
{
    static void Main(string[] args) {
        // Create a listener on port 8000
        string g = "\u001b[32m";
        string w = "\u001b[37m";
        string y = "\u001b[33m";
        HttpListener listener = new HttpListener();
        listener.Prefixes.Add("http://+:8000/");
        listener.Prefixes.Add("https://+:8443/");
        listener.AuthenticationSchemes = AuthenticationSchemes.Anonymous; // Default value
        listener.Start();
        Console.WriteLine("Listening ...");
        foreach (string prefix in listener.Prefixes) {
            Console.WriteLine($"Listening on : {y}{prefix}{w}");
        }
        while (listener.IsListening) {
          try {
             HttpListenerContext context = listener.GetContext();
             HttpListenerRequest request = context.Request;
             HttpListenerResponse response = context.Response;
             string url = (string)request.Url.AbsolutePath;
             if (request.Url.AbsolutePath.EndsWith("/end")) {
                 string message = String.Format("{0} {1}\nStop.", request.HttpMethod, url); 
                 byte[] buffer = Encoding.UTF8.GetBytes(message);
                 response.ContentType = "text/plain";
                 response.ContentLength64 = buffer.Length;
                 response.OutputStream.Write(buffer, 0, buffer.Length);
                 response.OutputStream.Close();
                 Console.WriteLine($"{w}Usage: {g}GET /api\n{w}Usage: {g}GET /end\n{w}Usage: {g}POST /api/v1/emp-profile\n{w}Usage: {g}POST /api/v1/update-status");
                 Console.WriteLine($"{w}{message}");
                 break;
            } else {
                string descr = "";
                string[] requestVars = request.Url.AbsolutePath.Split('/');
                int index = url.IndexOf("/api");
                string suburl = url.Substring(index, url.Length - index);
                string message = String.Format("{0} {1}", request.HttpMethod, suburl);
                switch (suburl) {
                    case "/api/v1/emp-profile":
                        if (request.HttpMethod=="POST") {
                            descr = " - Get Employee Profile";
                        } else {
                            descr = " - Invaid HTTP method.";
                        }
                        break;
                    case "/api/v1/update-status":
                        if (request.HttpMethod=="POST") {
                            using (System.IO.Stream body = request.InputStream) {
                                using (System.IO.StreamReader reader = new System.IO.StreamReader(body, request.ContentEncoding)) {
                                    string requestBody = reader.ReadToEnd();
                                    Console.WriteLine(requestBody);
                                    JObject jsonBody = JObject.Parse(requestBody);
                                    JObject json = new JObject();
                                    json.Add("employee_id", (string)jsonBody["employee_id"]);
                                    JObject jsonStat = (JObject )jsonBody["status"];
                                    json.Add("code", (string)jsonStat["code"]);
                                    json.Add("message", (string)jsonStat["message"]);
                                    Console.WriteLine(json);
                                }
                            }
                            descr = " - Update Registration Status";
                            message = "{\"code\": \"SUCCESS\", \"message\": \"Success\"}";
                            response.ContentType = "application/json";
                        } else {
                            descr = " - Invaid HTTP method.";
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine(String.Format("{0} {1}{2}", request.HttpMethod, suburl,descr ));
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                response.ContentType = "text/plain";
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
          } catch (Exception ex) { Console.WriteLine(ex.ToString());}
        }
        listener.Stop();   //Terminate the listener
        Console.WriteLine("Listener stop.");
    }
}
// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
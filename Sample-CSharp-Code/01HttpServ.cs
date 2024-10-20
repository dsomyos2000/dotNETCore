//##http://www.java2s.com/Code/CSharpAPI/System.Net/HttpListenerAuthenticationSchemes.htm
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;

public class MainClass
{
    public static void Main()
    {
        using (HttpListener listener = new HttpListener())
        {
            listener.AuthenticationSchemes = AuthenticationSchemes.Negotiate;
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Prefixes.Add("https://localhost/");
            listener.Start();

            HttpListenerContext ctx = listener.GetContext();
            ctx.Response.StatusCode = 200; 
            string name = ctx.Request.QueryString["name"];

            StreamWriter writer = new StreamWriter(ctx.Response.OutputStream);
            writer.WriteLine("<P>Hello, {0}</P>", name);
            
            writer.WriteLine("<ul>");
            foreach (string header in ctx.Request.Headers.Keys)
            {
                writer.WriteLine("<li><b>{0}:</b> {1}</li>",header, ctx.Request.Headers[header]);
            }
            writer.WriteLine("</ul>");

            writer.Close();
            ctx.Response.Close();
            listener.Stop();
        }
    }
}
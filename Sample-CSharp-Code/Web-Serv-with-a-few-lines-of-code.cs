//##https://weblog.west-wind.com/posts/2005/Dec/04/Add-a-Web-Server-to-your-NET-20-app-with-a-few-lines-of-code
using System;
using System.Text;
using System.Net;
using System.IO;
using Westwind.Tools;

namespace Westwind.InternetTools
{
    public delegate void delReceiveWebRequest(HttpListenerContext Context);

    /// <summary>
    /// Wrapper class for the HTTPListener to allow easier access to the
    /// server, for start and stop management and event routing of the actual
    /// inbound requests.
    /// </summary>
    public class HttpServer
    {

        protected HttpListener Listener;
        protected bool IsStarted = false;

        public event delReceiveWebRequest ReceiveWebRequest;

        public HttpServer()
        {
        }

        /// <summary>
        /// Starts the Web Service
        /// </summary>
        /// <param name="UrlBase">
        /// A Uri that acts as the base that the server is listening on.
        /// Format should be: http://127.0.0.1:8080/ or http://127.0.0.1:8080/somevirtual/
        /// Note: the trailing backslash is required! For more info see the
        /// HttpListener.Prefixes property on MSDN.
        /// </param>
        public void Start(string UrlBase)
        {
            // *** Already running - just leave it in place
            if (this.IsStarted)
                return;

            if (this.Listener == null)
            {
                this.Listener = new HttpListener();
            }

            this.Listener.Prefixes.Add(UrlBase);

            this.IsStarted = true;
            this.Listener.Start();

            IAsyncResult result = this.Listener.BeginGetContext( new AsyncCallback(WebRequestCallback), this.Listener );
        }

        /// <summary>
        /// Shut down the Web Service
        /// </summary>
        public void Stop()
        {
            if (Listener != null)
            {
                this.Listener.Close();
                this.Listener = null;
                this.IsStarted = false;
            }
        }


        protected void WebRequestCallback(IAsyncResult result)
        {
            if (this.Listener == null)
                return;

            // Get out the context object
            HttpListenerContext context = this.Listener.EndGetContext(result);

            // *** Immediately set up the next context
            this.Listener.BeginGetContext(new AsyncCallback(WebRequestCallback), this.Listener);

            if (this.ReceiveWebRequest != null)
                this.ReceiveWebRequest(context);

            this.ProcessRequest(context);
        }

        /// <summary>
        /// Overridable method that can be used to implement a custom hnandler
        /// </summary>
        /// <param name="Context"></param>
        protected virtual void ProcessRequest(HttpListenerContext Context)
        {
        }

    }
}

//To try this out throw a textbox and a couple buttons on the form, name the textbox txtUrl and btnStart, btnStop.

public partial class Form1 : Form
{
    public HttpServer Server = null;

    public Form1()
    {
        InitializeComponent();
        Server = new HttpProxyServer();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        this.Server.Start(this.txtUrl.Text);
    }

    private void btnStop_Click(object sender, EventArgs e)
    {
        this.Server.Stop();
    }
}

//In my case I’m testing out the behavior leading up to acting like a proxy, so I created a subclass called HttpProxy Server like this (which right now is merely echoing back the headers):

public class HttpProxyServer : HttpServer
{
    protected override void ProcessRequest(System.Net.HttpListenerContext Context)
    {
        HttpListenerRequest Request = Context.Request;
        HttpListenerResponse Response = Context.Response;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Request.HttpMethod + " " + Request.RawUrl + " Http/" + Request.ProtocolVersion.ToString());
        if (Request.UrlReferrer != null)
            sb.AppendLine("Referer: " + Request.UrlReferrer);
        if (Request.UserAgent != null)
            sb.AppendLine("User-Agent: " + Request.UserAgent);
        for (int x = 0; x < Request.Headers.Count; x++)
        {
            sb.AppendLine(Request.Headers.Keys[x] + ":" + " " + Request.Headers[x]);
        }
        sb.AppendLine();
        string Output = "<html><body><h1>Hello world</h1>Time is: " + DateTime.Now.ToString() +
            "<pre>" + sb.ToString() +  "</pre>";
        byte[] bOutput = System.Text.Encoding.UTF8.GetBytes(Output);
        Response.ContentType = "text/html";
        Response.ContentLength64 = bOutput.Length;
        Stream OutputStream = Response.OutputStream;
        OutputStream.Write(bOutput, 0, bOutput.Length);
        OutputStream.Close();
    }
}


using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

class WebServer {
    HttpListener myListener;
    string _baseFolder;     

    public WebServer(string uriPrefix, string baseFolder) {
        System.Threading.ThreadPool.SetMaxThreads(50, 1000);
        System.Threading.ThreadPool.SetMinThreads(50, 50);
        myListener = new HttpListener();
        myListener.Prefixes.Add(uriPrefix);
        _baseFolder = baseFolder;
    }

    public void Start() {                       
        myListener.Start();
        while (true)
            try {
                HttpListenerContext request = myListener.GetContext();
                ThreadPool.QueueUserWorkItem(ProcessRequest, request);
            } catch (HttpListenerException) { break; }  
            catch (InvalidOperationException) { break; }
    }

    public void Stop() { 
       myListener.Stop(); 
    }

    void ProcessRequest(object listenerContext) {
        try {
            var context = (HttpListenerContext)listenerContext;
            string filename = Path.GetFileName(context.Request.RawUrl);
            string path = Path.Combine(_baseFolder, filename);
            byte[] msg;
            if (!File.Exists(path)) {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                msg = Encoding.UTF8.GetBytes("Sorry, that page does not exist");
            } else {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                msg = File.ReadAllBytes(path);
            }
            context.Response.ContentLength64 = msg.Length;
            using (Stream s = context.Response.OutputStream)
                s.Write(msg, 0, msg.Length);
        } catch (Exception ex) { Console.WriteLine("Request error: " + ex); }
    }
}
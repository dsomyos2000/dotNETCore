//EXAMPLE #35
﻿namespace HDR.WebServer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    class cHttpServer
    {
        #region Nested Types

        public class HttpProcessor
        {
            #region Fields

            public Hashtable httpHeaders = new Hashtable();
            public String http_method;
            public String http_protocol_versionstring;
            public String http_url;
            public StreamWriter outputStream;
            public TcpClient socket;
            public HttpServer srv;

            private const int BUF_SIZE = 4096;

            private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

            private Stream inputStream;

            #endregion Fields

            #region Constructors

            public HttpProcessor(TcpClient s, HttpServer srv)
            {
                this.socket = s;
                this.srv = srv;
            }

            #endregion Constructors

            #region Methods

            public void handleGETRequest()
            {
                srv.handleGETRequest(this);
            }

            public void handlePOSTRequest()
            {
                // this post data processing just reads everything into a memory stream.
                // this is fine for smallish things, but for large stuff we should really
                // hand an input stream to the request processor. However, the input stream
                // we hand him needs to let him see the "end of the stream" at this content
                // length, because otherwise he won't know when he's seen it all!

                Console.WriteLine("get post data start");
                int content_len = 0;
                MemoryStream ms = new MemoryStream();
                if (this.httpHeaders.ContainsKey("Content-Length"))
                {
                    content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                    if (content_len > MAX_POST_SIZE)
                    {
                        throw new Exception(
                            String.Format("POST Content-Length({0}) too big for this simple server",
                              content_len));
                    }
                    byte[] buf = new byte[BUF_SIZE];
                    int to_read = content_len;
                    while (to_read > 0)
                    {
                        Console.WriteLine("starting Read, to_read={0}", to_read);

                        int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                        Console.WriteLine("read finished, numread={0}", numread);
                        if (numread == 0)
                        {
                            if (to_read == 0)
                            {
                                break;
                            }
                            else
                            {
                                throw new Exception("client disconnected during post");
                            }
                        }
                        to_read -= numread;
                        ms.Write(buf, 0, numread);
                    }
                    ms.Seek(0, SeekOrigin.Begin);
                }
                Console.WriteLine("get post data end");
                srv.handlePOSTRequest(this, new StreamReader(ms));
            }

            public void parseRequest()
            {
                String request = streamReadLine(inputStream);
                string[] tokens = request.Split(' ');
                if (tokens.Length != 3)
                {
                    throw new Exception("invalid http request line");
                }
                http_method = tokens[0].ToUpper();
                http_url = tokens[1];
                http_protocol_versionstring = tokens[2];

                Console.WriteLine("starting: " + request);
            }

            public void process()
            {
                // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
                // "processed" view of the world, and we want the data raw after the headers
                inputStream = new BufferedStream(socket.GetStream());

                // we probably shouldn't be using a streamwriter for all output from handlers either
                outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
                try
                {
                    parseRequest();
                    readHeaders();
                    if (http_method.Equals("GET"))
                    {
                        handleGETRequest();
                    }
                    else if (http_method.Equals("POST"))
                    {
                        handlePOSTRequest();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.ToString());
                    writeFailure();
                }
                outputStream.Flush();
                // bs.Flush(); // flush any remaining output
                inputStream = null; outputStream = null; // bs = null;
                socket.Close();
            }

            public void readHeaders()
            {
                Console.WriteLine("readHeaders()");
                String line;
                while ((line = streamReadLine(inputStream)) != null)
                {
                    if (line.Equals(""))
                    {
                        Console.WriteLine("got headers");
                        return;
                    }

                    int separator = line.IndexOf(':');
                    if (separator == -1)
                    {
                        throw new Exception("invalid http header line: " + line);
                    }
                    String name = line.Substring(0, separator);
                    int pos = separator + 1;
                    while ((pos < line.Length) && (line[pos] == ' '))
                    {
                        pos++; // strip any spaces
                    }

                    string value = line.Substring(pos, line.Length - pos);
                    Console.WriteLine("header: {0}:{1}", name, value);
                    httpHeaders[name] = value;
                }
            }

            public void writeFailure()
            {
                outputStream.WriteLine("HTTP/1.0 404 File not found");
                outputStream.WriteLine("Connection: close");
                outputStream.WriteLine("");
            }

            public void writeSuccess(string content_type = "text/html")
            {
                outputStream.WriteLine("HTTP/1.0 200 OK");
                outputStream.WriteLine("Content-Type: " + content_type);
                outputStream.WriteLine("Connection: close");
                outputStream.WriteLine("");
            }

            private string streamReadLine(Stream inputStream)
            {
                int next_char;
                string data = "";
                while (true)
                {
                    next_char = inputStream.ReadByte();
                    if (next_char == '\n') { break; }
                    if (next_char == '\r') { continue; }
                    if (next_char == -1) { Thread.Sleep(1); continue; };
                    data += Convert.ToChar(next_char);
                }
                return data;
            }

            #endregion Methods
        }

        public abstract class HttpServer
        {
            #region Fields

            protected int port;

            bool is_active = true;
            TcpListener listener;

            #endregion Fields

            #region Constructors

            public HttpServer(int port)
            {
                this.port = port;
            }

            #endregion Constructors

            #region Methods

            public abstract void handleGETRequest(HttpProcessor p);

            public abstract void handlePOSTRequest(HttpProcessor p, StreamReader inputData);

            public void listen()
            {
                listener = new TcpListener(cUtility.getLocalIP(),port);
                listener.Start();
                while (is_active)
                {
                    TcpClient s = listener.AcceptTcpClient();
                    HttpProcessor processor = new HttpProcessor(s, this);
                    Thread thread = new Thread(new ThreadStart(processor.process));
                    thread.Start();
                    Thread.Sleep(1);
                }
            }

            #endregion Methods
        }

        public class MyHttpServer : HttpServer
        {
            #region Constructors

            public MyHttpServer(int port)
                : base(port)
            {
            }

            #endregion Constructors

            #region Methods

            public override void handleGETRequest(HttpProcessor p)
            {
                switch (p.http_url)
                {
                    case "/channels":
                        p.writeSuccess("text/javascript");
                        //p.outputStream.WriteLine("{\"channel\":\"[{\"GuideNumber\":\"570\",\"GuideName\":\"ESPN\",\"LogoUrl\":\"http://192.168.1.23:888/logos/cbs.png\",\"Favorite\": true},{\"GuideNumber\":\"590\",\"GuideName\":\"FOX\",\"LogoUrl\":\"http://192.168.1.23:888/logos/cbs.png\",\"Favorite\": true},{\"GuideNumber\":\"600\",\"GuideName\":\"CBS\",\"LogoUrl\":\"http://192.168.1.23:888/logos/cbs.png\",\"Favorite\": true}]\"} ");
                        p.outputStream.WriteLine("{\"GuideNumber\":\"570\",\"GuideName\":\"ESPN\",\"LogoUrl\":\"http://192.168.1.23:888/logos/cbs.png\",\"Favorite\": true}");
                        break;

                    case "/favicon.png":
                        Stream fs = File.Open("../../favicon.png", FileMode.Open);
                        p.writeSuccess("image/png");
                        fs.CopyTo(p.outputStream.BaseStream);
                        p.outputStream.BaseStream.Flush();
                        break;

                    default:
                         Console.WriteLine("request: {0}", p.http_url);
                        p.writeSuccess();
                        p.outputStream.WriteLine("<html><body><h1>test server</h1>");
                        p.outputStream.WriteLine("Current Time: " + DateTime.Now.ToString());
                        p.outputStream.WriteLine("url : {0}", p.http_url);

                        p.outputStream.WriteLine("<form method=post action=/form>");
                        p.outputStream.WriteLine("<input type=text name=foo value=foovalue>");
                        p.outputStream.WriteLine("<input type=submit name=bar value=barvalue>");
                        p.outputStream.WriteLine("</form>");
                        break;
                }
            }

            public override void handlePOSTRequest(HttpProcessor p, StreamReader inputData)
            {
                Console.WriteLine("POST request: {0}", p.http_url);
                string data = inputData.ReadToEnd();

                p.writeSuccess();
                p.outputStream.WriteLine("<html><body><h1>test server</h1>");
                p.outputStream.WriteLine("<a href=/test>return</a><p>");
                p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);
            }

            #endregion Methods
        }

        #endregion Nested Types
    }
}
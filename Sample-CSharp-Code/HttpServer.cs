//EXAMPLE #3
#region Header
// Copyright (C) 2016 by David Jeske, Barend Erasmus and donated to the public domain
#endregion Header

namespace SimpleHttpServer
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    using log4net;

    using SimpleHttpServer;
    using SimpleHttpServer.Models;

    public class HttpServer
    {
        #region Fields

        private static readonly ILog log = LogManager.GetLogger(typeof(HttpServer));

        private bool IsActive = true;
        private TcpListener Listener;
        private int Port;
        private HttpProcessor Processor;

        #endregion Fields

        #region Constructors

        public HttpServer(int port, List<Route> routes)
        {
            this.Port = port;
            this.Processor = new HttpProcessor();

            foreach (var route in routes)
            {
                this.Processor.AddRoute(route);
            }
        }

        #endregion Constructors

        #region Methods

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);
            this.Listener.Start();
            while (this.IsActive)
            {
                TcpClient s = this.Listener.AcceptTcpClient();
                Thread thread = new Thread(() =>
                {
                    this.Processor.HandleClient(s);
                });
                thread.Start();
                Thread.Sleep(1);
            }
        }

        #endregion Methods
    }
}
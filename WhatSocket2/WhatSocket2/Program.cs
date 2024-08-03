using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace WhatSocket2
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            // default port
            int port = 8000;
            
            // checks for set port in terminal
            foreach (var arg in args)
            {
                if (arg.StartsWith("-port="))
                {
                    var parts = arg.Split('=');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int parsedPort))
                    {
                        port = parsedPort;
                    }
                }
            }

            int homePort = port;
            int addressPort = 0000;

            Form1 form = new Form1(homePort, addressPort);
            Server server = new Server(homePort, form);
            Client client = new Client();


            Application.Run(form);
        }
    }

    public class Server
    {
        private int port;
        private Form1 form;
        public Server(int port, Form1 form)
        {
            this.port = port;
            this.form = form;

            // start server listener
            TcpListener listener = new TcpListener(IPAddress.Any, this.port);
            listener.Start();

            form.InitChat();

        }
    }

    public class Client
    {
        public Client()
        {
            TcpClient client = new TcpClient();
            // NetworkStream stream = client.GetStream();

        }
    }
}
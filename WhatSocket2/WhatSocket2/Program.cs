using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatSocket2
{
    internal static class Program
    {
        private static Socket serverSocket;
        private static Form1 form;

        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            int port = 8000;

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

            // starts the server when application is initialized
            StartServer(port);

            form = new Form1(port);
            Application.Run(form);
        }

        // method that starts up server
        public static void StartServer(int port)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
            serverSocket.Listen(10);
            Task.Run(() => AcceptClientsAsync());
        }

        // method that accepts communication 
        private static async Task AcceptClientsAsync()
        {
            while (true)
            {
                Socket clientSocket = await Task.Factory.FromAsync(
                    serverSocket.BeginAccept,
                    serverSocket.EndAccept,
                    null);

                Task.Run(() => HandleClientAsync(clientSocket));
            }
        }

        private static async Task HandleClientAsync(Socket clientSocket)
        {
            byte[] buffer = new byte[clientSocket.ReceiveBufferSize];
            while (true)
            {
                int received = await Task.Factory.FromAsync<int>(
                    clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, null, null),
                    clientSocket.EndReceive);

                if (received > 0)
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, received);
                    form.ReceiveMessage(message, clientSocket.RemoteEndPoint.ToString());
                }
            }
        }

        // method that handles sending the message 
        public static void SendMessage(string serverIP, int serverPort, string message)
        {
            try
            {
                using (Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    clientSocket.Connect(new IPEndPoint(IPAddress.Parse(serverIP), serverPort));
                    byte[] data = Encoding.ASCII.GetBytes($"{form.username} ({form.homePort}): {message}");
                    clientSocket.Send(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}");
            }
        }
    }
}
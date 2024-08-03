using System;
using System.Net;
using System.Net.Sockets;

namespace WhatSocket2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
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

            int homePort = port;
            int addressPort = 0000;

            Form1 form1 = new Form1(homePort, addressPort);

            Application.Run(form1);
        }
    }
}
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WhatSocket2
{
    public partial class Form1 : Form
    {
        public int homePort;
        public int addressPort;
        public string localIP;
        public string username;

        public Form1(int homePort)
        {
            InitializeComponent();
            this.homePort = homePort;

            messageBox.ReadOnly = true;
            homePortBox.Enabled = false;
            homePortBox.Text = this.homePort.ToString();
        }

        public void InitChat()
        {
            messageBox.AppendText($"Initializing server on port {this.homePort}..." + "\r\n");
            messageBox.AppendText("Server started. Begin chat. :)" + "\r\n");
        }

        public void ReceiveMessage(string message, string clientEndpoint)
        {
            messageBox.Invoke(new Action(() =>
            {
                messageBox.AppendText($"{message}" + "\r\n");
            }));
        }

        private void sendMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                messageBox.AppendText($"{username}: {message}" + "\r\n");

                Program.SendMessage(localIP, addressPort, message);
            }
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = entryBox.Text;
            sendMessage(message);
        }

        private void addressPortBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.addressPort = int.Parse(addressPortBox.Text);
                localIP = GetLocalIPAddress();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            if (ipAddress == null)
            {
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            return ipAddress.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(usernameBox.Text))
            {
                username = "User";
            }
            else
            {
                username = usernameBox.Text;
            }
        }
    }
}
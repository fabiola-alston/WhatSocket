using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WhatSocket2
{
    public partial class Form1 : Form
    {
        // class variables
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

        // method that handles receiving the message and displaying it in the message box
        public void ReceiveMessage(string message, string clientEndpoint)
        {
            messageBox.Invoke(new Action(() =>
            {
                messageBox.AppendText($"{message}" + "\r\n");
            }));
        }

        // shows message that client sent put on screen
        private void sendMessage(string message)
        {
            if (!string.IsNullOrWhiteSpace(message))
            {
                messageBox.AppendText($"{username} (you): {message}" + "\r\n");

                Program.SendMessage(localIP, addressPort, message);
            }
        }

        // listener for button click
        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = entryBox.Text;
            sendMessage(message);
        }

        // listener for address port text box (typing changes)
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

        // gets local ip address
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

        // ignore this pls :) (the program breaks if you remove it idk why)
        private void label4_Click(object sender, EventArgs e)
        {

        }

        // username box listener (same as address port text box listener)
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
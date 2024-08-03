using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatSocket
{
    public partial class Form1 : Form
    {
        private int hostPort = 8000;
        private int addressPort;
        private string addressPortString;

        public Form1()
        {
            InitializeComponent();
            // chat box is non editable
            chatBox.Enabled = false;
            chatBox.ReadOnly = true;

            // port home box is non editable
            hostPortBox.Enabled = false;
            hostPortBox.ReadOnly = true;

            // adds own port to host port box
            hostPortBox.Text = hostPort.ToString();
            
        }

        private void sendMessage()
        {
            string input = textBox1.Text;
            chatBox.AppendText($"You ({hostPort}): {input}" + "\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendMessage();
      
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            addressPortString = addressPortBox.Text;
            addressPort = Convert.ToInt32(addressPortBox.Text);
        }
    }
}

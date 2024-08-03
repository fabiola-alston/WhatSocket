namespace WhatSocket2
{
    public partial class Form1 : Form
    {
        public int homePort;
        public int addressPort;
        public string sentMessage;

        public Form1(int homePort, int addressPort)
        {
            InitializeComponent();
            this.homePort = homePort;
            this.addressPort = addressPort;

            messageBox.ReadOnly = true;
            homePortBox.Enabled = false;
            homePortBox.Text = this.homePort.ToString();

        }

        // method for initializing chat
        public void InitChat()
        {
            messageBox.AppendText($"Initializing server on port {this.homePort}..." + "\r\n");
            messageBox.AppendText("Server started. Begin chat. :)" + "\r\n");
        }

        // method for sending message (button)
        private void sendMessage(string message)
        {
            this.sentMessage = message;
            messageBox.AppendText($"You ({this.homePort}): {message}" + "\r\n");
        }


        private void sendButton_Click(object sender, EventArgs e)
        {
            string message = entryBox.Text;
            sendMessage(message);
        }

        private void addressPortBox_TextChanged(object sender, EventArgs e)
        {
            this.addressPort = int.Parse(addressPortBox.Text);
        }
    }
}

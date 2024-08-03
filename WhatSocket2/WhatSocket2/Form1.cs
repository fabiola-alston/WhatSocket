namespace WhatSocket2
{
    public partial class Form1 : Form
    {
        public int homePort;
        public int addressPort;

        public Form1(int homePort, int addressPort)
        {
            InitializeComponent();
            this.homePort = homePort;
            this.addressPort = addressPort;

            messageBox.ReadOnly = true;
            homePortBox.Enabled = false;
            homePortBox.Text = this.homePort.ToString();

        }

        private void sendMessage()
        {
            string message = entryBox.Text;
            messageBox.AppendText($"You ({this.homePort}): {message}" + "\r\n");
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            sendMessage();
        }

        private void addressPortBox_TextChanged(object sender, EventArgs e)
        {
            this.addressPort = int.Parse(addressPortBox.Text);
        }
    }
}

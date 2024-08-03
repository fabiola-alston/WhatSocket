namespace WhatSocket2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            entryBox = new TextBox();
            sendButton = new Button();
            messageBox = new TextBox();
            label2 = new Label();
            homePortBox = new TextBox();
            label3 = new Label();
            addressPortBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 15);
            label1.TabIndex = 0;
            label1.Text = "★ Enter message:";
            // 
            // entryBox
            // 
            entryBox.Location = new Point(12, 27);
            entryBox.Name = "entryBox";
            entryBox.Size = new Size(200, 23);
            entryBox.TabIndex = 1;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(12, 56);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(75, 23);
            sendButton.TabIndex = 2;
            sendButton.Text = "Send!";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // messageBox
            // 
            messageBox.Location = new Point(246, 12);
            messageBox.Multiline = true;
            messageBox.Name = "messageBox";
            messageBox.Size = new Size(226, 437);
            messageBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(126, 15);
            label2.TabIndex = 4;
            label2.Text = "Server started on port: ";
            // 
            // homePortBox
            // 
            homePortBox.Location = new Point(144, 92);
            homePortBox.Name = "homePortBox";
            homePortBox.Size = new Size(80, 23);
            homePortBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 126);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 6;
            label3.Text = "Enter port address:";
            // 
            // addressPortBox
            // 
            addressPortBox.Location = new Point(123, 123);
            addressPortBox.Name = "addressPortBox";
            addressPortBox.Size = new Size(80, 23);
            addressPortBox.TabIndex = 7;
            addressPortBox.TextChanged += addressPortBox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(484, 461);
            Controls.Add(addressPortBox);
            Controls.Add(label3);
            Controls.Add(homePortBox);
            Controls.Add(label2);
            Controls.Add(messageBox);
            Controls.Add(sendButton);
            Controls.Add(entryBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "WhatSocket";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox entryBox;
        private Button sendButton;
        private TextBox messageBox;
        private Label label2;
        private TextBox homePortBox;
        private Label label3;
        private TextBox addressPortBox;
    }
}

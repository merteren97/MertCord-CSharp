namespace MertCord_Client.Forms
{
    partial class ChatForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSend;
        private TextBox txtMessage;
        private ListBox lstMessages;
        private Label lblUsername;
        private Button btnVoiceChat;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnSend = new Button();
            txtMessage = new TextBox();
            lstMessages = new ListBox();
            lblUsername = new Label();
            btnVoiceChat = new Button();
            SuspendLayout();
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom;
            btnSend.Location = new Point(297, 190);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Anchor = AnchorStyles.Bottom;
            txtMessage.Location = new Point(12, 190);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(279, 23);
            txtMessage.TabIndex = 2;
            txtMessage.KeyPress += txtMessage_KeyPress;
            // 
            // lstMessages
            // 
            lstMessages.FormattingEnabled = true;
            lstMessages.ItemHeight = 15;
            lstMessages.Location = new Point(12, 42);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(360, 139);
            lstMessages.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(63, 15);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Logged in:";
            // 
            // btnVoiceChat
            // 
            btnVoiceChat.Anchor = AnchorStyles.Bottom;
            btnVoiceChat.Location = new Point(12, 219);
            btnVoiceChat.Name = "btnVoiceChat";
            btnVoiceChat.Size = new Size(360, 33);
            btnVoiceChat.TabIndex = 5;
            btnVoiceChat.Text = "Voice Chat";
            btnVoiceChat.UseVisualStyleBackColor = true;
            btnVoiceChat.Click += btnVoiceChat_Click;
            // 
            // ChatForm
            // 
            ClientSize = new Size(384, 263);
            Controls.Add(btnVoiceChat);
            Controls.Add(lblUsername);
            Controls.Add(lstMessages);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Name = "ChatForm";
            Text = "Chat Client";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

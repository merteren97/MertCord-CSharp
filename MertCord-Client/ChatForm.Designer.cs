namespace MertCord_Client
{
    partial class ChatForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnConnect;
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
            btnConnect = new Button();
            btnSend = new Button();
            txtMessage = new TextBox();
            lstMessages = new ListBox();
            lblUsername = new Label();
            btnVoiceChat = new Button();
            SuspendLayout();
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(12, 261);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(360, 33);
            btnConnect.TabIndex = 0;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(297, 222);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 33);
            btnSend.TabIndex = 1;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 224);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(279, 27);
            txtMessage.TabIndex = 2;
            txtMessage.KeyPress += txtMessage_KeyPress;
            // 
            // lstMessages
            // 
            lstMessages.FormattingEnabled = true;
            lstMessages.Location = new Point(12, 42);
            lstMessages.Name = "lstMessages";
            lstMessages.Size = new Size(360, 144);
            lstMessages.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(12, 9);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(79, 20);
            lblUsername.TabIndex = 4;
            lblUsername.Text = "Logged in:";
            // 
            // btnVoiceChat
            // 
            btnVoiceChat.Location = new Point(12, 310);
            btnVoiceChat.Name = "btnVoiceChat";
            btnVoiceChat.Size = new Size(360, 33);
            btnVoiceChat.TabIndex = 5;
            btnVoiceChat.Text = "Voice Chat";
            btnVoiceChat.UseVisualStyleBackColor = true;
            btnVoiceChat.Click += btnVoiceChat_Click;
            // 
            // ChatForm
            // 
            ClientSize = new Size(384, 361);
            Controls.Add(btnVoiceChat);
            Controls.Add(lblUsername);
            Controls.Add(lstMessages);
            Controls.Add(txtMessage);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Name = "ChatForm";
            Text = "Chat Client";
            Load += ChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

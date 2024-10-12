namespace MertCord_Client.Forms
{
    partial class VoiceChatForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnJoinChannel;
        private Button btnMute;
        private Button btnOpenSettings;

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
            this.btnJoinChannel = new System.Windows.Forms.Button();
            this.btnMute = new System.Windows.Forms.Button();
            this.btnOpenSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnJoinChannel
            // 
            this.btnJoinChannel.Location = new System.Drawing.Point(12, 12);
            this.btnJoinChannel.Name = "btnJoinChannel";
            this.btnJoinChannel.Size = new System.Drawing.Size(260, 23);
            this.btnJoinChannel.TabIndex = 0;
            this.btnJoinChannel.Text = "Join Voice Channel";
            this.btnJoinChannel.UseVisualStyleBackColor = true;
            this.btnJoinChannel.Click += new System.EventHandler(this.btnJoinChannel_Click);
            // 
            // btnMute
            // 
            this.btnMute.Location = new System.Drawing.Point(12, 50);
            this.btnMute.Name = "btnMute";
            this.btnMute.Size = new System.Drawing.Size(260, 23);
            this.btnMute.TabIndex = 1;
            this.btnMute.Text = "Mute";
            this.btnMute.UseVisualStyleBackColor = true;
            this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
            // 
            // btnOpenSettings
            // 
            this.btnOpenSettings.Location = new System.Drawing.Point(12, 90);
            this.btnOpenSettings.Name = "btnOpenSettings";
            this.btnOpenSettings.Size = new System.Drawing.Size(260, 23);
            this.btnOpenSettings.TabIndex = 2;
            this.btnOpenSettings.Text = "Open Voice Settings";
            this.btnOpenSettings.UseVisualStyleBackColor = true;
            this.btnOpenSettings.Click += new System.EventHandler(this.btnOpenSettings_Click);
            // 
            // VoiceChatForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.btnOpenSettings);
            this.Controls.Add(this.btnMute);
            this.Controls.Add(this.btnJoinChannel);
            this.Name = "VoiceChatForm";
            this.Text = "Voice Chat";
            this.ResumeLayout(false);
        }
    }
}
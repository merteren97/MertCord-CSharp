namespace MertCord_Client.Forms
{
    partial class VoiceSettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cbMicrophone;
        private ComboBox cbSpeakers;
        private Button btnApplySettings;
        private Label lblMicrophone;
        private Label lblSpeakers;

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
            this.cbMicrophone = new System.Windows.Forms.ComboBox();
            this.cbSpeakers = new System.Windows.Forms.ComboBox();
            this.btnApplySettings = new System.Windows.Forms.Button();
            this.lblMicrophone = new System.Windows.Forms.Label();
            this.lblSpeakers = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbMicrophone
            // 
            this.cbMicrophone.FormattingEnabled = true;
            this.cbMicrophone.Location = new System.Drawing.Point(12, 32);
            this.cbMicrophone.Name = "cbMicrophone";
            this.cbMicrophone.Size = new System.Drawing.Size(260, 21);
            this.cbMicrophone.TabIndex = 0;
            // 
            // cbSpeakers
            // 
            this.cbSpeakers.FormattingEnabled = true;
            this.cbSpeakers.Location = new System.Drawing.Point(12, 85);
            this.cbSpeakers.Name = "cbSpeakers";
            this.cbSpeakers.Size = new System.Drawing.Size(260, 21);
            this.cbSpeakers.TabIndex = 1;
            // 
            // btnApplySettings
            // 
            this.btnApplySettings.Location = new System.Drawing.Point(12, 126);
            this.btnApplySettings.Name = "btnApplySettings";
            this.btnApplySettings.Size = new System.Drawing.Size(260, 23);
            this.btnApplySettings.TabIndex = 2;
            this.btnApplySettings.Text = "Apply Settings";
            this.btnApplySettings.UseVisualStyleBackColor = true;
            this.btnApplySettings.Click += new System.EventHandler(this.btnApplySettings_Click);
            // 
            // lblMicrophone
            // 
            this.lblMicrophone.AutoSize = true;
            this.lblMicrophone.Location = new System.Drawing.Point(12, 16);
            this.lblMicrophone.Name = "lblMicrophone";
            this.lblMicrophone.Size = new System.Drawing.Size(61, 13);
            this.lblMicrophone.TabIndex = 3;
            this.lblMicrophone.Text = "Microphone";
            // 
            // lblSpeakers
            // 
            this.lblSpeakers.AutoSize = true;
            this.lblSpeakers.Location = new System.Drawing.Point(12, 69);
            this.lblSpeakers.Name = "lblSpeakers";
            this.lblSpeakers.Size = new System.Drawing.Size(52, 13);
            this.lblSpeakers.TabIndex = 4;
            this.lblSpeakers.Text = "Speakers";
            // 
            // VoiceSettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.lblSpeakers);
            this.Controls.Add(this.lblMicrophone);
            this.Controls.Add(this.btnApplySettings);
            this.Controls.Add(this.cbSpeakers);
            this.Controls.Add(this.cbMicrophone);
            this.Name = "VoiceSettingsForm";
            this.Text = "Voice Settings";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

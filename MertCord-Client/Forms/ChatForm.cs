using MertCord_Client.Services;

namespace MertCord_Client.Forms
{
    public partial class ChatForm : Form
    {
        private string _userName;

        public ChatForm(string userName) => Init(userName);
        private void Init(string userName)
        {
            InitializeComponent();
            _userName = userName;
            lblUsername.Text = $"Logged in as: {userName}";
            Task.Run(() => APIGateway.Instance().TCPConnect());
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                APIGateway.Instance().TCPSendMessage(_userName, txtMessage.Text);
                txtMessage.Clear();
            }
        }
        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e) => btnSend.PerformClick();
        private void btnVoiceChat_Click(object sender, EventArgs e)
        {
            VoiceChatForm voiceChatForm = new VoiceChatForm();
            voiceChatForm.Show();
        }
    }
}
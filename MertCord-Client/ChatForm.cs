using MertCord_Client.Forms;
using MertCord_Client.Services;
using System.Net.Sockets;
using System.Text;

namespace MertCord_Client
{
    public partial class ChatForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string username;

        public ChatForm()
        {
            InitializeComponent();
            LoadUsernameOrAsk();
        }

        private void LoadUsernameOrAsk()
        {
            if (APIGateway.Instance().Username_Get() == null)
            {
                username = Prompt.ShowDialog("Enter your username:", "Username");
                APIGateway.Instance().Username_Set(username);
            }
            lblUsername.Text = $"Logged in as: {username}";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient(Environment.GetEnvironmentVariable("SERVER_URL")!, 5000);
            stream = client.GetStream();

            new Thread(ReceiveMessages).Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string message = $"{username}: {txtMessage.Text}";
            byte[] buffer = Encoding.ASCII.GetBytes(message);
            stream.Write(buffer, 0, buffer.Length);
            txtMessage.Clear();
        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Invoke(new Action(() => lstMessages.Items.Add(message)));
            }
        }

        private void btnVoiceChat_Click(object sender, EventArgs e)
        {
            VoiceChatForm voiceChatForm = new VoiceChatForm();
            voiceChatForm.Show();
        }

        private void ChatForm_Load(object sender, EventArgs e)
        {

        }

        private void txtMessage_KeyPress(object sender, KeyPressEventArgs e) => btnSend.PerformClick();
    }
}
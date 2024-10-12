using MertCord_Client.Services;

namespace MertCord_Client.Forms
{
    public partial class Login : Form
    {
        public Login() => InitializeComponent();
        private void Login_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(APIGateway.Instance().Username_Get()))
            {
                ChatForm chat = new ChatForm(APIGateway.Instance().Username_Get());
                chat.ShowDialog();
                this.Close();
            }
        }
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUserName.Text))
            {
                APIGateway.Instance().Username_Set(txtUserName.Text);
                ChatForm chat = new ChatForm(txtUserName.Text);
                chat.ShowDialog();
            }
        }
    }
}
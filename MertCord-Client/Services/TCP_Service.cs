using DotNetEnv;
using MertCord_Client.Models.DB;
using System.Net.Sockets;
using System.Text;

namespace MertCord_Client.Services
{
    public class TCP_Service : SingletonManager<TCP_Service>
    {
        private TcpClient client;
        private NetworkStream stream;
        public event Action NewMessageReceived; // Yeni mesaj bildirimi aldığında tetiklenecek event
        public bool isListening;

        public async Task ConnectToServerAsync()
        {
            client = new TcpClient();
            await client.ConnectAsync(Env.GetString("SERVER_URL"), Env.GetInt("SERVER_PORT"));
            stream = client.GetStream();
            isListening = true;
            ListenForNotificationsAsync(); // Bildirimleri dinlemeyi asenkron başlat
        }
        public async Task SendMessageToServerAsync(string userName, string message)
        {
            // Mesajı veritabanına kaydet
            APIGateway.Instance().ChatInsert(new Chat_TBL { UserName = userName, Message = message });

            // Server'a "NEW_MESSAGE" sinyali gönder
            byte[] buffer = Encoding.ASCII.GetBytes(Env.GetString("TOKEN") + "_" + "NEW_MESSAGE");
            await stream.WriteAsync(buffer, 0, buffer.Length); // Asenkron yazma
        }
        private async Task ListenForNotificationsAsync()
        {
            byte[] buffer = new byte[1024];
            while (isListening && client.Connected)
            {
                int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (byteCount == 0) // Bağlantı kapatıldı
                    break;

                string data = Encoding.ASCII.GetString(buffer, 0, byteCount);
                if (data == "NEW_MESSAGE")
                {
                    OnNewMessageReceived(); // Event'i tetikle
                }
            }

            client.Close(); // Client bağlantısı kapatıldı
        }
        public void OnNewMessageReceived() => NewMessageReceived?.Invoke();
    }
}
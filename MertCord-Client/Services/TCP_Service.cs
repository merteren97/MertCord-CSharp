using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MertCord_Client.Services
{
    public class TCP_Service : SingletonManager<TCP_Service>
    {
        private TcpClient client;
        private NetworkStream stream;
        public event Action NewMessageReceived; // Yeni mesaj bildirimi aldığında tetiklenecek event

        public async Task ConnectToServerAsync(CancellationToken token)
        {
            client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 5000);
            stream = client.GetStream();
            Console.WriteLine("Connected to server.");

            ListenForNotificationsAsync(token); // Bildirimleri dinlemeyi asenkron başlat
        }

        public async Task SendMessageToServerAsync(string message)
        {
            // Mesajı veritabanına kaydet
            await SaveMessageToDatabaseAsync(message);

            // Server'a "NEW_MESSAGE" sinyali gönder
            byte[] buffer = Encoding.ASCII.GetBytes("NEW_MESSAGE");
            await stream.WriteAsync(buffer, 0, buffer.Length); // Asenkron yazma
        }

        private async Task ListenForNotificationsAsync(CancellationToken token)
        {
            byte[] buffer = new byte[1024];

            while (!token.IsCancellationRequested && client.Connected)
            {
                int byteCount = await stream.ReadAsync(buffer, 0, buffer.Length, token);

                if (byteCount == 0) // Bağlantı kapatıldı
                    break;

                string data = Encoding.ASCII.GetString(buffer, 0, byteCount);
                if (data == "NEW_MESSAGE_NOTIFICATION")
                {
                    Console.WriteLine("New message notification received.");
                    OnNewMessageReceived(); // Event'i tetikle
                }
            }

            client.Close(); // Client bağlantısı kapatıldı
        }

        public void OnNewMessageReceived()
        {
            NewMessageReceived?.Invoke();
            FetchMessagesFromDatabase(); // Yeni mesajları veritabanından çek
        }
    }
}
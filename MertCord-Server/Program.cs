using Npgsql;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DotNetEnv;
class ChatServer
{
    private TcpListener tcpListener;
    private UdpClient udpServer;
    private List<TcpClient> clients = new List<TcpClient>();
    private IPEndPoint udpRemoteEndPoint;
    private string connectionString;

    public ChatServer(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void Start()
    {
        Env.Load();
        // TCP Sunucu başlat
        tcpListener = new TcpListener(IPAddress.Any, Env.GetInt("SERVER_PORT"));
        tcpListener.Start();

        // UDP Sunucu başlat
        udpServer = new UdpClient(Env.GetInt("SERVER_PORT_UDP"));
        udpRemoteEndPoint = new IPEndPoint(IPAddress.Any, Env.GetInt("SERVER_PORT_UDP"));

        // TCP ve UDP işlemleri için ayrı thread'ler başlat
        new System.Threading.Thread(HandleTcpClients).Start();
        new System.Threading.Thread(HandleUdpClients).Start();
    }

    private void HandleTcpClients()
    {
        while (true)
        {
            TcpClient client = tcpListener.AcceptTcpClient();
            clients.Add(client);
            new System.Threading.Thread(() => HandleClientMessages(client)).Start();
        }
    }

    private void HandleClientMessages(TcpClient client)
    {
        NetworkStream stream = client.GetStream();
        byte[] buffer = new byte[1024];
        int bytesRead;

        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
        {
            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received message: " + message);
            //SaveMessageToDatabase(message);
            BroadcastMessage(message, client);
        }
    }

    private void SaveMessageToDatabase(string message)
    {
        using (var conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand("INSERT INTO messages (message) VALUES (@message)", conn))
            {
                cmd.Parameters.AddWithValue("message", message);
                cmd.ExecuteNonQuery();
            }
        }
    }

    private void BroadcastMessage(string message, TcpClient senderClient)
    {
        byte[] buffer = Encoding.ASCII.GetBytes(message);
        foreach (var client in clients)
        {
            if (client != senderClient)
            {
                NetworkStream stream = client.GetStream();
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }

    private void HandleUdpClients()
    {
        while (true)
        {
            byte[] receivedData = udpServer.Receive(ref udpRemoteEndPoint);
            BroadcastVoiceData(receivedData, udpRemoteEndPoint);
        }
    }

    private void BroadcastVoiceData(byte[] data, IPEndPoint senderEndPoint)
    {
        foreach (var client in clients)
        {
            udpServer.Send(data, data.Length, udpRemoteEndPoint);
        }
    }
    static void Main(string[] args)
    {
        string connectionString = $"";
        ChatServer server = new ChatServer(connectionString);
        server.Start();
    }
}
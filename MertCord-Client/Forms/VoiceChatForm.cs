using NAudio.Wave;
using System.Net;
using System.Net.Sockets;

namespace MertCord_Client.Forms
{
    public partial class VoiceChatForm : Form
    {
        private WaveIn waveIn;
        private WaveOut waveOut;
        private UdpClient udpClient;
        private BufferedWaveProvider bufferedWaveProvider;
        private bool isMuted = false;

        public VoiceChatForm()
        {
            InitializeComponent();
        }

        private void btnJoinChannel_Click(object sender, EventArgs e)
        {
            // UDP istemcisi başlatılır
            udpClient = new UdpClient();

            // Mikrofon girişini başlat
            waveIn = new WaveIn();
            waveIn.WaveFormat = new WaveFormat(8000, 1); // Mono, 8kHz
            waveIn.DataAvailable += OnDataAvailable;
            waveIn.StartRecording();

            // Hoparlör çıkışını başlat
            waveOut = new WaveOut();
            bufferedWaveProvider = new BufferedWaveProvider(new WaveFormat(8000, 1));
            waveOut.Init(bufferedWaveProvider);
            waveOut.Play();

            // UDP üzerinden ses verisini dinlemek için thread başlat
            Thread listenThread = new Thread(ListenForIncomingAudio);
            listenThread.Start();
        }

        // Mikrofon sesini alıp sunucuya gönderme
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (!isMuted)
            {
                // Mikrofon verisini UDP ile sunucuya gönder
                udpClient.Send(e.Buffer, e.Buffer.Length, "127.0.0.1", 5001);
            }
        }

        // UDP üzerinden gelen ses verisini dinleme ve oynatma
        private void ListenForIncomingAudio()
        {
            UdpClient listener = new UdpClient(5001); // Gelen veriyi dinle
            while (true)
            {
                try
                {
                    IPEndPoint groupEP = new IPEndPoint(System.Net.IPAddress.Any, 5001);
                    byte[] receiveData = listener.Receive(ref groupEP);

                    // Veriyi oynatmak için bufferedWaveProvider'a ekle
                    bufferedWaveProvider.AddSamples(receiveData, 0, receiveData.Length);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        // Mikrofon mute/unmute işlemi
        private void btnMute_Click(object sender, EventArgs e)
        {
            isMuted = !isMuted;
            btnMute.Text = isMuted ? "Unmute" : "Mute";
        }

        // Ses ayarları penceresi açma
        private void btnOpenSettings_Click(object sender, EventArgs e)
        {
            VoiceSettingsForm settingsForm = new VoiceSettingsForm();
            settingsForm.ShowDialog();
        }
    }
}
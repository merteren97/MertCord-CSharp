using NAudio.CoreAudioApi;

namespace MertCord_Client.Forms
{
    public partial class VoiceSettingsForm : Form
    {
        private MMDeviceEnumerator enumerator;
        private MMDevice selectedMicrophone;
        private MMDevice selectedSpeaker;

        public VoiceSettingsForm()
        {
            InitializeComponent();
            enumerator = new MMDeviceEnumerator();
            LoadAudioDevices();
        }

        private void LoadAudioDevices()
        {
            var microphones = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active);
            foreach (var mic in microphones)
            {
                cbMicrophone.Items.Add(mic.FriendlyName);
            }

            var speakers = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);
            foreach (var speaker in speakers)
            {
                cbSpeakers.Items.Add(speaker.FriendlyName);
            }

            if (cbMicrophone.Items.Count > 0)
            {
                cbMicrophone.SelectedIndex = 0;
                selectedMicrophone = microphones[0];
            }

            if (cbSpeakers.Items.Count > 0)
            {
                cbSpeakers.SelectedIndex = 0;
                selectedSpeaker = speakers[0];
            }
        }

        private void btnApplySettings_Click(object sender, EventArgs e)
        {
            selectedMicrophone = enumerator.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active)[cbMicrophone.SelectedIndex];
            selectedSpeaker = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)[cbSpeakers.SelectedIndex];
            MessageBox.Show("Settings Applied", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
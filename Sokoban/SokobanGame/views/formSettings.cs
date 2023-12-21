using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class formSettings : Form
    {
        RegistrySettings registrySettings = new RegistrySettings();

        public formSettings()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = registrySettings.SkinId;
            pictureBox1.BackgroundImage = (registrySettings.SoundIsEnabled) ? (Properties.Resources.soundOn) : (Properties.Resources.soundOff);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            registrySettings.SoundIsEnabled = !registrySettings.SoundIsEnabled;
            pictureBox1.BackgroundImage = (registrySettings.SoundIsEnabled) ? (Properties.Resources.soundOn) : (Properties.Resources.soundOff);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Goldenrod;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            registrySettings.SkinId = comboBox1.SelectedIndex;
            MessageBox.Show("Настройки успешно сохранены!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
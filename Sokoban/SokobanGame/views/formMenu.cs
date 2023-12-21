using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Security.Cryptography;

namespace Sokoban
{
    public partial class formMenu : Form
    {
        public formMenu()
        {
            InitializeComponent();
            try
            {
                String[] args = Environment.GetCommandLineArgs();
                if (args[1] == "-adminmode")
                {
                    this.Text = "adminmode - activated";
                    button1.Visible = true;
                    button2.Visible = true;
                }
            }
            catch (Exception)
            {
            }
        }

        #region labelColor

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.ForeColor = Color.Goldenrod;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            label2.ForeColor = Color.Goldenrod;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseMove(object sender, MouseEventArgs e)
        {
            label3.ForeColor = Color.Goldenrod;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            label4.ForeColor = Color.Goldenrod;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            label5.ForeColor = Color.Goldenrod;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            label6.ForeColor = Color.Goldenrod;
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FilePathsConstants.LEVEL_FILES_DIRECTORY))
            {
                formGame formGame = new formGame();
                this.Hide();
                formGame.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Уровни игры отсутствуют!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FilePathsConstants.LEVEL_FILES_DIRECTORY))
            {
                try
                {
                    OpenFileDialog openLVL = new OpenFileDialog();
                    openLVL.Filter = "Save files|*.save";
                    openLVL.FileName = "Player.save";

                    if (DialogResult.OK == openLVL.ShowDialog())
                    {
                        SokobanGame sokobanGame = new SokobanGame(openLVL.FileName, Path.GetFileNameWithoutExtension(openLVL.FileName));
                        formGame formGame = new formGame(sokobanGame);

                        this.Hide();
                        formGame.ShowDialog();
                        this.Show();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Сохранение повреждено!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Уровни игры отсутствуют!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            formSettings formSettings = new formSettings();
            this.Hide();
            formSettings.ShowDialog();
            this.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(FilePathsConstants.SAVE_FILES_DIRECTORY))
            {
                formRecords formRecords = new formRecords();
                ISokobanRecords sokobanGame = new SokobanGame();

                string[] saves = Directory.GetFiles(FilePathsConstants.SAVE_FILES_DIRECTORY, "*.save");

                for (int i = 0; i < saves.Length; i++)
                {
                    formRecords.listBox1.Items.Add(Path.GetFileNameWithoutExtension(saves[i]));
                    formRecords.listBox1.Items.Add("Пройдено уровней: " + sokobanGame.GetCompletedLevelsCount(saves[i]));
                    formRecords.listBox1.Items.Add("");
                }

                this.Hide();
                formRecords.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Файлы статистики отсутствуют!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            formRules formRules = new formRules();
            if (File.Exists(@"Rules.rul"))
             {
                 try
                 {
                     XmlDocument doc = new XmlDocument();
                     CspParameters cspParams = new CspParameters();
                     cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
                     RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                     doc.Load(@"Rules.rul");
                     CryptographyXml.DecryptXml(doc, rsaKey, "Sokoban");
                     doc.Save(@"Rules.rul");

                     XDocument xdoc = XDocument.Load(@"Rules.rul");
                     formRules.label1.Text = xdoc.Element("Sokoban").Element("Rules").Value;

                     doc.Load(@"Rules.rul");
                     CryptographyXml.EncryptXml(doc, "Sokoban", rsaKey, "Sokoban");
                     doc.Save(@"Rules.rul");

                     rsaKey.Clear();

                     this.Hide();
                     formRules.ShowDialog();
                     this.Show();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                 }
             }
             else
             {
                 MessageBox.Show("Файл правил отсутствует!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  try
            {
                OpenFileDialog openLVL = new OpenFileDialog();

                if (DialogResult.OK == openLVL.ShowDialog())
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    CspParameters cspParams = new CspParameters();
                    cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
                    RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                    xmlDoc.Load(openLVL.FileName);
                    Saves.DecryptXML(xmlDoc, rsaKey, "Sokoban");
                    xmlDoc.Save(openLVL.FileName);

                    rsaKey.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
         /*   try
            {
                OpenFileDialog openLVL = new OpenFileDialog();

                if (DialogResult.OK == openLVL.ShowDialog())
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    CspParameters cspParams = new CspParameters();
                    cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
                    RSACryptoServiceProvider rsaKey = new RSACryptoServiceProvider(cspParams);

                    xmlDoc.Load(openLVL.FileName);
                    Saves.EncryptXML(xmlDoc, "Sokoban", rsaKey, "Sokoban");
                    xmlDoc.Save(openLVL.FileName);

                    rsaKey.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }*/
        }
    }
}
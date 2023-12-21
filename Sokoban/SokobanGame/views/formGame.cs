using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class formGame : Form
    {
        private string playerName = "Player";
        private ISokobanGame sokobanGame;
        private Size levelSize;

        public formGame(ISokobanGame sokobanGame)
        {
            InitializeComponent();

            if (sokobanGame != null)
            {
                this.sokobanGame = sokobanGame;
                DrawLevel();
            }
        }

        public formGame()
        {
            InitializeComponent();

            if (InputBox("Введите ваше имя:", ref playerName) == DialogResult.OK)
            {
                playerName = (playerName == "") ? ("Player") : (playerName);
            }


            sokobanGame = new SokobanGame(playerName);
            
            DrawLevel();
        }

        private void DrawLevel()
        {
            levelSize = sokobanGame.LevelSize;

            ClientSize = new Size(levelSize.Width + 230, levelSize.Height + 28);

            pictureBox.Size = new Size(levelSize.Width, levelSize.Height);

            groupBox.Size = new Size(200, levelSize.Height);
            groupBox.Location = new Point(levelSize.Width + 20, 12);

            playerNameTitle.Location = new Point(9, 40);
            playerNameLabel.Location = new Point(65, 40);

            currentLevelTitle.Location = new Point(9, 80);
            currentLevelLabel.Location = new Point(85, 80);

            movesCountTitle.Location = new Point(9, 120);
            movesCountLabel.Location = new Point(127, 120);

            pushesCountTitle.Location = new Point(9, 160);
            pushesCountLabel.Location = new Point(75, 160);

            levelsCountTitle.Location = new Point(9, 200);
            levelsCountLabel.Location = new Point(140, 200);

            restartLevelButton.Location = new Point(42, 280);
            undoButton.Location = new Point(27, 330);
            newGameButton.Location = new Point(24, 380);

            pictureBox.Image = sokobanGame.LevelImage;

            playerNameLabel.Text = sokobanGame.PlayerName;
            currentLevelLabel.Text = sokobanGame.CurrentLevel.ToString();
            movesCountLabel.Text = sokobanGame.MovesCount.ToString();
            pushesCountLabel.Text = sokobanGame.PushesCount.ToString();
            levelsCountLabel.Text = sokobanGame.LevelsCount.ToString();

            //Refresh();
        }

        private void restartLevelButton_Click(object sender, EventArgs e)
        {
            sokobanGame.RestartLevel();
            DrawLevel();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            sokobanGame.Undo();
            pictureBox.Image = sokobanGame.LevelImage;

            movesCountLabel.Text = sokobanGame.MovesCount.ToString();
            pushesCountLabel.Text = sokobanGame.PushesCount.ToString();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            sokobanGame.StartNewGame();
            DrawLevel();
        }

        private void formGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData.ToString())
            {
                case "Up":
                    sokobanGame.MovePlayer(MoveDirection.Up);
                    break;

                case "Down":
                    sokobanGame.MovePlayer(MoveDirection.Down);
                    break;

                case "Right":
                    sokobanGame.MovePlayer(MoveDirection.Right);
                    break;

                case "Left":
                    sokobanGame.MovePlayer(MoveDirection.Left);
                    break;

                case "U":
                    sokobanGame.Undo();
                    break;
            }


            pictureBox.Image = sokobanGame.LevelImage;

            movesCountLabel.Text = sokobanGame.MovesCount.ToString();
            pushesCountLabel.Text = sokobanGame.PushesCount.ToString();

            if (sokobanGame.CheckVictory())
            {
                if (sokobanGame.StartNextLevel())
                {
                    MessageBox.Show("Вы успешно прошли уровень!");
                    DrawLevel();
                }
                else
                {
                    MessageBox.Show("Вы прошли последний уровень, игра окончера!");
                    this.Close();
                }
            }
        }

        #region labelColor

        private void restartLevelButton_MouseLeave(object sender, EventArgs e)
        {
            restartLevelButton.ForeColor = Color.Black;
        }

        private void restartLevelButton_MouseMove(object sender, MouseEventArgs e)
        {
            restartLevelButton.ForeColor = Color.Goldenrod;
        }

        private void undoButton_MouseLeave(object sender, EventArgs e)
        {
            undoButton.ForeColor = Color.Black;
        }

        private void undoButton_MouseMove(object sender, MouseEventArgs e)
        {
            undoButton.ForeColor = Color.Goldenrod;
        }

        private void newGameButton_MouseLeave(object sender, EventArgs e)
        {
            newGameButton.ForeColor = Color.Black;
        }

        private void newGameButton_MouseMove(object sender, MouseEventArgs e)
        {
            newGameButton.ForeColor = Color.Goldenrod;
        }

        #endregion

        public DialogResult InputBox(string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();

            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonOk.DialogResult = DialogResult.OK;

            label.SetBounds(9, 20, 172, 13);
            textBox.SetBounds(12, 36, 172, 20);
            buttonOk.SetBounds(59, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(196, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(200, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;

            textBox.MaxLength = 10;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }
}

namespace Sokoban
{
    partial class formGame
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formGame));
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.playerNameTitle = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Label();
            this.undoButton = new System.Windows.Forms.Label();
            this.restartLevelButton = new System.Windows.Forms.Label();
            this.levelsCountLabel = new System.Windows.Forms.Label();
            this.levelsCountTitle = new System.Windows.Forms.Label();
            this.pushesCountLabel = new System.Windows.Forms.Label();
            this.movesCountLabel = new System.Windows.Forms.Label();
            this.currentLevelLabel = new System.Windows.Forms.Label();
            this.pushesCountTitle = new System.Windows.Forms.Label();
            this.movesCountTitle = new System.Windows.Forms.Label();
            this.currentLevelTitle = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.Transparent;
            this.groupBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox.Controls.Add(this.playerNameLabel);
            this.groupBox.Controls.Add(this.playerNameTitle);
            this.groupBox.Controls.Add(this.newGameButton);
            this.groupBox.Controls.Add(this.undoButton);
            this.groupBox.Controls.Add(this.restartLevelButton);
            this.groupBox.Controls.Add(this.levelsCountLabel);
            this.groupBox.Controls.Add(this.levelsCountTitle);
            this.groupBox.Controls.Add(this.pushesCountLabel);
            this.groupBox.Controls.Add(this.movesCountLabel);
            this.groupBox.Controls.Add(this.currentLevelLabel);
            this.groupBox.Controls.Add(this.pushesCountTitle);
            this.groupBox.Controls.Add(this.movesCountTitle);
            this.groupBox.Controls.Add(this.currentLevelTitle);
            this.groupBox.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox.Location = new System.Drawing.Point(422, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(200, 400);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Статистика: ";
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerNameLabel.Location = new System.Drawing.Point(65, 40);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(140, 18);
            this.playerNameLabel.TabIndex = 12;
            this.playerNameLabel.Text = "playerNameLabel";
            // 
            // playerNameTitle
            // 
            this.playerNameTitle.AutoSize = true;
            this.playerNameTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerNameTitle.Location = new System.Drawing.Point(9, 40);
            this.playerNameTitle.Name = "playerNameTitle";
            this.playerNameTitle.Size = new System.Drawing.Size(59, 18);
            this.playerNameTitle.TabIndex = 11;
            this.playerNameTitle.Text = "Игрок:";
            // 
            // newGameButton
            // 
            this.newGameButton.AutoSize = true;
            this.newGameButton.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newGameButton.Location = new System.Drawing.Point(24, 318);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(154, 29);
            this.newGameButton.TabIndex = 10;
            this.newGameButton.Text = "Новая игра";
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            this.newGameButton.MouseLeave += new System.EventHandler(this.newGameButton_MouseLeave);
            this.newGameButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.newGameButton_MouseMove);
            // 
            // undoButton
            // 
            this.undoButton.AutoSize = true;
            this.undoButton.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.undoButton.Location = new System.Drawing.Point(27, 278);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(145, 29);
            this.undoButton.TabIndex = 9;
            this.undoButton.Text = "Шаг назад";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            this.undoButton.MouseLeave += new System.EventHandler(this.undoButton_MouseLeave);
            this.undoButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.undoButton_MouseMove);
            // 
            // restartLevelButton
            // 
            this.restartLevelButton.AutoSize = true;
            this.restartLevelButton.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.restartLevelButton.Location = new System.Drawing.Point(42, 238);
            this.restartLevelButton.Name = "restartLevelButton";
            this.restartLevelButton.Size = new System.Drawing.Size(111, 29);
            this.restartLevelButton.TabIndex = 8;
            this.restartLevelButton.Text = "Рестарт";
            this.restartLevelButton.Click += new System.EventHandler(this.restartLevelButton_Click);
            this.restartLevelButton.MouseLeave += new System.EventHandler(this.restartLevelButton_MouseLeave);
            this.restartLevelButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.restartLevelButton_MouseMove);
            // 
            // levelsCountLabel
            // 
            this.levelsCountLabel.AutoSize = true;
            this.levelsCountLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelsCountLabel.Location = new System.Drawing.Point(140, 200);
            this.levelsCountLabel.Name = "levelsCountLabel";
            this.levelsCountLabel.Size = new System.Drawing.Size(137, 18);
            this.levelsCountLabel.TabIndex = 7;
            this.levelsCountLabel.Text = "levelsCountLabel";
            // 
            // levelsCountTitle
            // 
            this.levelsCountTitle.AutoSize = true;
            this.levelsCountTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.levelsCountTitle.Location = new System.Drawing.Point(9, 200);
            this.levelsCountTitle.Name = "levelsCountTitle";
            this.levelsCountTitle.Size = new System.Drawing.Size(134, 18);
            this.levelsCountTitle.TabIndex = 6;
            this.levelsCountTitle.Text = "Кол-во уровней:";
            // 
            // pushesCountLabel
            // 
            this.pushesCountLabel.AutoSize = true;
            this.pushesCountLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pushesCountLabel.Location = new System.Drawing.Point(75, 160);
            this.pushesCountLabel.Name = "pushesCountLabel";
            this.pushesCountLabel.Size = new System.Drawing.Size(144, 18);
            this.pushesCountLabel.TabIndex = 5;
            this.pushesCountLabel.Text = "pushesCountLabel";
            // 
            // movesCountLabel
            // 
            this.movesCountLabel.AutoSize = true;
            this.movesCountLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.movesCountLabel.Location = new System.Drawing.Point(125, 120);
            this.movesCountLabel.Name = "movesCountLabel";
            this.movesCountLabel.Size = new System.Drawing.Size(140, 18);
            this.movesCountLabel.TabIndex = 4;
            this.movesCountLabel.Text = "movesCountLabel";
            // 
            // currentLevelLabel
            // 
            this.currentLevelLabel.AutoSize = true;
            this.currentLevelLabel.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentLevelLabel.Location = new System.Drawing.Point(85, 80);
            this.currentLevelLabel.Name = "currentLevelLabel";
            this.currentLevelLabel.Size = new System.Drawing.Size(145, 18);
            this.currentLevelLabel.TabIndex = 3;
            this.currentLevelLabel.Text = "currentLevelLabel";
            // 
            // pushesCountTitle
            // 
            this.pushesCountTitle.AutoSize = true;
            this.pushesCountTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pushesCountTitle.Location = new System.Drawing.Point(9, 160);
            this.pushesCountTitle.Name = "pushesCountTitle";
            this.pushesCountTitle.Size = new System.Drawing.Size(68, 18);
            this.pushesCountTitle.TabIndex = 2;
            this.pushesCountTitle.Text = "Толчки:";
            // 
            // movesCountTitle
            // 
            this.movesCountTitle.AutoSize = true;
            this.movesCountTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.movesCountTitle.Location = new System.Drawing.Point(9, 120);
            this.movesCountTitle.Name = "movesCountTitle";
            this.movesCountTitle.Size = new System.Drawing.Size(121, 18);
            this.movesCountTitle.TabIndex = 1;
            this.movesCountTitle.Text = "Перемещения:";
            // 
            // currentLevelTitle
            // 
            this.currentLevelTitle.AutoSize = true;
            this.currentLevelTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.currentLevelTitle.Location = new System.Drawing.Point(9, 80);
            this.currentLevelTitle.Name = "currentLevelTitle";
            this.currentLevelTitle.Size = new System.Drawing.Size(77, 18);
            this.currentLevelTitle.TabIndex = 0;
            this.currentLevelTitle.Text = "Уровень:";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Location = new System.Drawing.Point(12, 14);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // formGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sokoban.Properties.Resources.gameBackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 427);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.groupBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formGame_KeyDown);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label pushesCountLabel;
        private System.Windows.Forms.Label movesCountLabel;
        private System.Windows.Forms.Label currentLevelLabel;
        private System.Windows.Forms.Label pushesCountTitle;
        private System.Windows.Forms.Label movesCountTitle;
        private System.Windows.Forms.Label currentLevelTitle;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label levelsCountLabel;
        private System.Windows.Forms.Label levelsCountTitle;
        private System.Windows.Forms.Label newGameButton;
        private System.Windows.Forms.Label undoButton;
        private System.Windows.Forms.Label restartLevelButton;
        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.Label playerNameTitle;
    }
}
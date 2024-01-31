namespace Snake
{
    partial class Snake
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            OnePlayer = new Button();
            TwoPlayer = new Button();
            StartGame = new Button();
            Player1Score = new Label();
            Player2Score = new Label();
            GameOverLabel = new Label();
            ThreePlayer = new Button();
            Player3Score = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ControlDark;
            pictureBox1.Location = new Point(27, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(528, 396);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // OnePlayer
            // 
            OnePlayer.BackColor = Color.FromArgb(0, 192, 0);
            OnePlayer.FlatAppearance.BorderSize = 0;
            OnePlayer.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 0);
            OnePlayer.FlatAppearance.MouseOverBackColor = Color.Green;
            OnePlayer.FlatStyle = FlatStyle.Flat;
            OnePlayer.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            OnePlayer.Location = new Point(634, 68);
            OnePlayer.Name = "OnePlayer";
            OnePlayer.Size = new Size(130, 37);
            OnePlayer.TabIndex = 1;
            OnePlayer.Text = "One Player";
            OnePlayer.UseVisualStyleBackColor = false;
            OnePlayer.Click += OnePlayer_Click;
            // 
            // TwoPlayer
            // 
            TwoPlayer.BackColor = Color.FromArgb(255, 128, 0);
            TwoPlayer.FlatAppearance.BorderSize = 0;
            TwoPlayer.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 128, 0);
            TwoPlayer.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 64, 0);
            TwoPlayer.FlatStyle = FlatStyle.Flat;
            TwoPlayer.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            TwoPlayer.Location = new Point(634, 127);
            TwoPlayer.Name = "TwoPlayer";
            TwoPlayer.Size = new Size(130, 39);
            TwoPlayer.TabIndex = 2;
            TwoPlayer.Text = "Two Player";
            TwoPlayer.UseVisualStyleBackColor = false;
            TwoPlayer.Click += TwoPlayer_Click;
            // 
            // StartGame
            // 
            StartGame.BackColor = Color.FromArgb(0, 192, 192);
            StartGame.FlatAppearance.BorderSize = 0;
            StartGame.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 192, 192);
            StartGame.FlatAppearance.MouseOverBackColor = Color.Teal;
            StartGame.FlatStyle = FlatStyle.Flat;
            StartGame.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            StartGame.Location = new Point(634, 374);
            StartGame.Name = "StartGame";
            StartGame.Size = new Size(130, 42);
            StartGame.TabIndex = 3;
            StartGame.Text = "Start Game";
            StartGame.UseVisualStyleBackColor = false;
            StartGame.Click += StartGame_Click;
            // 
            // Player1Score
            // 
            Player1Score.AutoSize = true;
            Player1Score.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Player1Score.ForeColor = Color.FromArgb(0, 192, 0);
            Player1Score.Location = new Point(634, 228);
            Player1Score.Name = "Player1Score";
            Player1Score.Size = new Size(67, 18);
            Player1Score.TabIndex = 4;
            Player1Score.Text = "Score: 0";
            Player1Score.Click += Player1Score_Click;
            // 
            // Player2Score
            // 
            Player2Score.AutoSize = true;
            Player2Score.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Player2Score.ForeColor = Color.FromArgb(255, 128, 0);
            Player2Score.Location = new Point(634, 264);
            Player2Score.Name = "Player2Score";
            Player2Score.Size = new Size(67, 18);
            Player2Score.TabIndex = 5;
            Player2Score.Text = "Score: 0";
            Player2Score.Click += Player2Score_Click;
            // 
            // GameOverLabel
            // 
            GameOverLabel.AutoSize = true;
            GameOverLabel.BackColor = SystemColors.ControlDark;
            GameOverLabel.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point);
            GameOverLabel.Location = new Point(200, 125);
            GameOverLabel.Name = "GameOverLabel";
            GameOverLabel.Size = new Size(168, 33);
            GameOverLabel.TabIndex = 6;
            GameOverLabel.Text = "Game Over!";
            // 
            // ThreePlayer
            // 
            ThreePlayer.BackColor = Color.SkyBlue;
            ThreePlayer.Location = new Point(634, 182);
            ThreePlayer.Name = "ThreePlayer";
            ThreePlayer.Size = new Size(125, 23);
            ThreePlayer.TabIndex = 7;
            ThreePlayer.Text = "Three Player";
            ThreePlayer.UseVisualStyleBackColor = false;
            ThreePlayer.Click += ThreePlayer_Click;
            // 
            // Player3Score
            // 
            Player3Score.AutoSize = true;
            Player3Score.Font = new Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            Player3Score.ForeColor = Color.SkyBlue;
            Player3Score.Location = new Point(634, 299);
            Player3Score.Name = "Player3Score";
            Player3Score.Size = new Size(67, 18);
            Player3Score.TabIndex = 8;
            Player3Score.Text = "Score: 0";
            Player3Score.Click += label1_Click_1;
            // 
            // Snake
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Player3Score);
            Controls.Add(ThreePlayer);
            Controls.Add(GameOverLabel);
            Controls.Add(Player2Score);
            Controls.Add(Player1Score);
            Controls.Add(StartGame);
            Controls.Add(TwoPlayer);
            Controls.Add(OnePlayer);
            Controls.Add(pictureBox1);
            Name = "Snake";
            Text = "Snake!";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Button OnePlayer;
        private Button TwoPlayer;
        private Button StartGame;
        private Label Player1Score;
        private Label Player2Score;
        private Label GameOverLabel;
       
        private Button ThreePlayer;
        private Label Player3Score;
    }
}
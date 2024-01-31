using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Snake
{


    public partial class Snake : Form
    {
        private Engine engine;
        private Timer gameTimer;
        private int playerCount;
        private bool gameStarted;
        private int tileSize = 10;
        public static int GridWidth { get; set; }
        public static int GridHeight { get; set; }
        public static bool gameOver { get; set; }
        public Snake()
        {
            InitializeComponent();
            GameOverLabel.Visible = false;
            KeyPreview = true;
            KeyDown += Snake_KeyDown;
            engine = new Engine(this);
            engine.ScoreChanged += Engine_ScoreChanged;
            gameTimer = new Timer { Interval = 100 };
            gameTimer.Tick += TimerEventHandler;
            pictureBox1.Paint += pictureBox1_Paint;
            playerCount = 1;
            GridWidth = pictureBox1.Width / tileSize;
            GridHeight = pictureBox1.Height / tileSize;
        }

        private void Snake_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                //Player 1 controls
                case Keys.W:
                    if (engine.Player1.CurrentDirection != Direction.Down)
                        engine.Player1.CurrentDirection = Direction.Up;
                    break;
                case Keys.A:
                    if (engine.Player1.CurrentDirection != Direction.Right)
                        engine.Player1.CurrentDirection = Direction.Left;
                    break;
                case Keys.S:
                    if (engine.Player1.CurrentDirection != Direction.Up)
                        engine.Player1.CurrentDirection = Direction.Down;
                    break;
                case Keys.D:
                    if (engine.Player1.CurrentDirection != Direction.Left)
                        engine.Player1.CurrentDirection = Direction.Right;
                    break;

                //Player 2 controls

                case Keys.I:
                    if (engine.Player2.CurrentDirection != Direction.Down)
                        engine.Player2.CurrentDirection = Direction.Up;
                    break;
                case Keys.J:
                    if (engine.Player2.CurrentDirection != Direction.Right)
                        engine.Player2.CurrentDirection = Direction.Left;
                    break;
                case Keys.K:
                    if (engine.Player2.CurrentDirection != Direction.Up)
                        engine.Player2.CurrentDirection = Direction.Down;
                    break;
                case Keys.L:
                    if (engine.Player2.CurrentDirection != Direction.Left)
                        engine.Player2.CurrentDirection = Direction.Right;
                    break;


            }
        }

        private void TwoPlayer_Click(object sender, EventArgs e)
        {
            playerCount = 2;
        }

        private void OnePlayer_Click(object sender, EventArgs e)
        {
            playerCount = 1;
        }

        private void StartGame_Click(object sender, EventArgs e)
        {


            GameOverLabel.Visible = false;
            Player1Score.Text = "Score: 0";
            Player2Score.Text = "Score: 0";


            if (!gameStarted)
            {
                engine.Initialize(playerCount);
                gameTimer.Start();
                gameStarted = true;
                OnePlayer.Enabled = false;
                TwoPlayer.Enabled = false;
                StartGame.Text = "Restart";

            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {


            engine.Draw(e.Graphics, tileSize);

        }
        private void TimerEventHandler(object sender, EventArgs e)
        {
            engine.Update();
            pictureBox1.Invalidate();
            
            if (gameOver)
            {
                
                gameTimer.Stop();
                gameStarted = false;
                OnePlayer.Enabled = true;
                TwoPlayer.Enabled = true;
                StartGame.Text = "Start";
                gameOver = false;
            }

        }

        private void Engine_ScoreChanged(object sender, ScoreEventArgs e)
        {
            Player1Score.Text = "Score: " + e.Player1Score.ToString();
            Player2Score.Text = "Score: " + e.Player2Score.ToString();
        }

        public void GameOver()
        {
            GameOverLabel.Visible = true;
        }

        private void Player1Score_Click(object sender, EventArgs e)
        {

        }

        private void Player2Score_Click(object sender, EventArgs e)
        {

        }
    }
}
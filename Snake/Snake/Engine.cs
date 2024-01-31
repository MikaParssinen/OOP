using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Snake
{

    public class Engine
    {
        PaintEventArgs e;
        public SnakeEntity Player1 { get; set; }
        public SnakeEntity Player2 { get; set; }
        private Food food;
       
        public event EventHandler<ScoreEventArgs> ScoreChanged;
        private int PlayerCount;

        private Snake SnakeForm;

        public Engine(Snake form)
        {
            SnakeForm = form;
            Player1 = new SnakeEntity(Direction.Right);
            Player2 = new SnakeEntity(Direction.Down);
            e = new PaintEventArgs(SnakeForm.CreateGraphics(), SnakeForm.ClientRectangle);
            
        }

        public void Initialize(int playerCount)
        {
            PlayerCount = playerCount;
            Player1.AddPoints(0);
            Player2.AddPoints(0);

            Player1.Pieces.Clear();
            Player2.Pieces.Clear();
         
            Player1.AddPiece(3);
            
            // Set starting positions and lengths for Player 2

            if (playerCount > 1)
            {
                Player2.AddPiece(3);
            }
            
            
            //ScoreChanged?.Invoke(this, new ScoreEventArgs { Player1Score = Player1.Points, Player2Score = Player2.Points });
            GenerateFood();
            
        }

        public void Update()
        {
            // Update the position of the snake pieces

            Player1.MoveSnake();
            Player2.MoveSnake();

            if (Player1.CheckFoodCollision(food.X, food.Y) == true)
            {
                if (food.Length > 0)
                {
                    Player1.AddPiece(food.Length);
                    Player1.AddPoints(food.Points);
                }

                else
                {
                    Player1.AddPoints(food.Points);
                    Player1.RemoveLastPiece();
                } 
                food = null;
                GenerateFood();

                
            }
            if(Player2.CheckFoodCollision(food.X, food.Y) == true)
            {
                if (food.Length > 0)
                {
                    Player2.AddPiece(food.Length);
                    Player2.AddPoints(food.Points);
                }

                else
                {
                    Player2.AddPoints(food.Points);
                    Player2.RemoveLastPiece();
                }

                food = null;
                GenerateFood();
            }

            Player1.CheckSelfCollision();

            if (Player1.CheckSelfCollision())
            {
                Player1.PlayerDeath();

                if (Player2.Pieces.Count < 1)
                {
                    GameOver();
                }

            }

            if (PlayerCount == 2)
            {

                if (Player2.CheckSelfCollision())
                {
                    Player2.PlayerDeath();

                    if (Player1.Pieces.Count < 1)
                    {
                        GameOver();
                    }
                }
            }

            // Check for collisions with other players
            if (Player1.CheckSnakeCollision(Player2))
            {
                Player1.PlayerDeath();
                Player2.AddPoints(5);

                if (Player2.Pieces.Count < 1)
                {
                    GameOver();
                }
            }

            if (Player2.CheckSnakeCollision(Player1))
            {
                Player2.PlayerDeath();
                Player1.AddPoints(5);

                if (Player1.Pieces.Count < 1)
                {
                    GameOver();
                }
            }
            ScoreChanged?.Invoke(this, new ScoreEventArgs { Player1Score = Player1.Points, Player2Score = Player2.Points });

        }

        public void GenerateFood()
        {
            Random random = new Random();
            int x, y;


            x = random.Next(Snake.GridWidth);
            y = random.Next(Snake.GridHeight);

            int rand = random.Next(100);

            if (rand < 70)
            {
                food = new StandardFood(x, y);
                food.Draw(e.Graphics, 10);
            }
            else if (rand < 90)
            {
                food = new ValuableFood(x, y);
                food.Draw(e.Graphics, 10);
            }
            else
            {
                food = new DietFood(x, y);
                food.Draw(e.Graphics, 10);

            }

        }
        
        public void Draw(Graphics g, int tileSize = 10)
        {
            if (food != null)
            {
                g.FillRectangle(food.Color, food.X * tileSize, food.Y * tileSize, tileSize, tileSize);
            }
            
            Player1.DrawSnake(g, tileSize, Brushes.Green);
            Player2.DrawSnake(g, tileSize, Brushes.Blue);
        }
        
        
        
        private void GameOver()
        {
            Player1.RemovePoints(Player1.Points);
            Player2.RemovePoints(Player2.Points);
            SnakeForm.GameOver();
            Snake.gameOver = true;
        
        }
    }

        
}

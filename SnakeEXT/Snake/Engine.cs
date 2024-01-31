using Snake;
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
        public SnakeEntity Player3 { get; set; }
        private Food food;
        Random random1 = new Random();

        private int Intervall2 = 0;




        public event EventHandler<ScoreEventArgs> ScoreChanged;
        private int PlayerCount;

        private Snake SnakeForm;

        public Engine(Snake form)
        {
            SnakeForm = form;
            Player1 = new SnakeEntity(Direction.Right);
            Player2 = new SnakeEntity(Direction.Down);
            Player3 = new SnakeEntity(Direction.Left);
            e = new PaintEventArgs(SnakeForm.CreateGraphics(), SnakeForm.ClientRectangle);
            Player1.CurrentDirection = Direction.Right;

        }





        public void Initialize(int playerCount)
        {
            PlayerCount = playerCount;
            Player1.AddPoints(0);
            Player2.AddPoints(0);
            Player3.AddPoints(0);

            Player1.Pieces.Clear();
            Player2.Pieces.Clear();
            Player3.Pieces.Clear();


            Player1.AddPiece(3);

            // Set starting positions and lengths for Player 2

            if (playerCount == 2)
            {
                Player2.AddPiece(3);
            }
            else if (playerCount == 3)
            {
                Player2.AddPiece(3);
                Player3.AddPiece(3);
            }


            GenerateFood();


        }

        public void Update()
        {
            // Update the position of the snake pieces

            Player1.MoveSnake();
            Player2.MoveSnake();
            Player3.MoveSnake();
           
            //Makes new intervall each tick
            Intervall2 = random1.Next(1,3);
            


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

                if (food.IsRandomOut == true)
                {
                    Player1.IsRandomEaten = true;
                }
                food = null;
                GenerateFood();



            }
            if (Player2.CheckFoodCollision(food.X, food.Y) == true)
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
                if (food.IsRandomOut == true)
                {
                    Player2.IsRandomEaten = true;
                }

                food = null;
                GenerateFood();
            }
            if (Player3.CheckFoodCollision(food.X, food.Y) == true)
            {
                if (food.Length > 0)
                {
                    Player3.AddPiece(food.Length);
                    Player3.AddPoints(food.Points);
                }
                else
                {
                    Player3.AddPoints(food.Points);
                    Player3.RemoveLastPiece();
                }

                if (food.IsRandomOut == true)
                {
                    Player3.IsRandomEaten = true;
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
            else if (PlayerCount == 3)
            {
                if (Player2.CheckSelfCollision())
                {
                    Player2.PlayerDeath();

                    if (Player1.Pieces.Count < 1)
                    {
                        GameOver();
                    }
                }
                if (Player3.CheckSelfCollision())
                {
                    Player3.PlayerDeath();

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
            if (Player1.CheckSnakeCollision(Player3))
            {
                Player1.PlayerDeath();
                Player3.AddPoints(5);

                if (Player3.Pieces.Count < 1)
                {
                    GameOver();
                }
            }
            if (Player3.CheckSnakeCollision(Player1))
            {
                Player3.PlayerDeath();
                Player1.AddPoints(5);

                if (Player1.Pieces.Count < 1)
                {
                    GameOver();
                }
            }
            if (Player2.CheckSnakeCollision(Player3))
            {
                Player2.PlayerDeath();
                Player3.AddPoints(5);

                if (Player3.Pieces.Count < 1)
                {
                    GameOver();
                }
            }
            if (Player3.CheckSnakeCollision(Player2))
            {
                Player3.PlayerDeath();
                Player2.AddPoints(5);

                if (Player2.Pieces.Count < 1)
                {
                    GameOver();
                }
            }

            //Check if random is eaten
            if (Player1.IsRandomEaten == true)
            {
                if (Player1.Intervall <= 300)
                {
                    Player1.SetIntervall();
                    if (Player1.Intervall % 10 == Intervall2)
                    {
                        MakeRandomMove(Player1);
                    }
                    if(Player1.Intervall == 0)
                    {
                        Player1.IsRandomEaten = false;
                    }
                }
                
            }
            if (Player2.IsRandomEaten == true)
            {
                
                if (Player2.Intervall <= 300)
                {
                  

                    Player2.SetIntervall();
                    if (Player2.Intervall % 10 == Intervall2)
                    {
                        MakeRandomMove(Player2);
                        
                    }
                    if (Player2.Intervall == 0)
                    {
                        Player2.IsRandomEaten = false;
                    }
                }
               
            }

            if (Player3.IsRandomEaten == true)
            {

                
                if (Player3.Intervall <= 300) 
                {
                    Player3.SetIntervall();
                    if (Player3.Intervall % 10 == Intervall2)
                    {
                        MakeRandomMove(Player3);
                    }
                    if (Player3.Intervall == 0)
                    {
                        Player3.IsRandomEaten = false;
                    }
                }
                
                
            }
        

            ScoreChanged?.Invoke(this, new ScoreEventArgs { Player1Score = Player1.Points, Player2Score = Player2.Points, Player3Score = Player3.Points });

        }

        public void GenerateFood()
        {
            Random random = new Random();
            int x, y;

            for ( int i = 0; i<3; i++) 
            { 
                x = random.Next(Snake.GridWidth);
                y = random.Next(Snake.GridHeight);

                int rand = random.Next(100);

                if (rand < 30)
                {
                    food = new DietFood(x, y);
                    food.Draw(e.Graphics, 10);
                }
                else if (rand < 40)
                {
                    food = new ValuableFood(x, y);
                    food.Draw(e.Graphics, 10);
                }
                else if(rand < 80)
                {
                    food = new RandomDirrFood(x, y);
                    food.Draw(e.Graphics, 10);
                }
                else
                {
                    food = new StandardFood(x, y);
                    food.Draw(e.Graphics, 10);
                   
                }

           
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
            Player3.DrawSnake(g, tileSize, Brushes.Red);
        }
        
        
        
        private void GameOver()
        {
            Player1.RemovePoints(Player1.Points);
            Player2.RemovePoints(Player2.Points);
            Player3.RemovePoints(Player3.Points);
            SnakeForm.GameOver();
            Snake.gameOver = true;
        
        }


        private void MakeRandomMove(SnakeEntity Player)
        {
                       
            Random ran = new Random();               
            int dir = ran.Next(1, 6);

            if (dir == 1)
            {
                if (Player.CurrentDirection != Direction.Up)
                {
                    Player.CurrentDirection = Direction.Down;
                    Player.MoveSnake();
                }

            }
            else if (dir == 2)
            {
                if (Player.CurrentDirection != Direction.Down)
                {
                    Player.CurrentDirection = Direction.Up;
                    Player.MoveSnake();
                }

            }
            else if (dir == 3)
            {
                if (Player.CurrentDirection != Direction.Left)
                { 
                    Player.CurrentDirection = Direction.Right;
                    Player.MoveSnake();
                }
            }                    
            else if(dir == 4)                    
            {
                if(Player.CurrentDirection != Direction.Right)
                {
                    Player.CurrentDirection = Direction.Left;
                    Player.MoveSnake();
                }      
                    
            }
            else
            {
                return;
            }

        }










        



















    }

}

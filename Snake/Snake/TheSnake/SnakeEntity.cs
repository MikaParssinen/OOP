using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakeEntity
    {
        public List<SnakePiece> Pieces { get; private set; }
        public Direction CurrentDirection { get; set; }
        public int Points { get; private set; }
        
        public SnakeEntity(Direction initialDirection)
        {
            Pieces = new List<SnakePiece>();
            CurrentDirection = initialDirection;
            Points = 0;
        }
    

        public void DrawSnake(Graphics graphics, int tileSize, Brush bodyColor)
        {
            if (Pieces.Count == 0)
            {
                return;
            }

            // Draw the head of the snake with a different color
            SnakePiece head = Pieces[0];
            graphics.FillEllipse(Brushes.Black, head.X * tileSize, head.Y * tileSize, tileSize, tileSize);

            // Draw the body of the snake
            for (int i = 1; i < Pieces.Count; i++)
            {
                SnakePiece piece = Pieces[i];
                graphics.FillEllipse(bodyColor, piece.X * tileSize, piece.Y * tileSize, tileSize, tileSize);
            }
        }

        public void RemovePoints(int value)
        {
            this.Points = this.Points - value;
        }

        public void MoveSnake()
        {
            if (Pieces.Count < 1)
                return;

            int newX = Pieces[0].X;
            int newY = Pieces[0].Y;

            switch (CurrentDirection)
            {
                case Direction.Up:
                    newY--;
                    break;
                case Direction.Down:
                    newY++;
                    break;
                case Direction.Left:
                    newX--;
                    break;
                case Direction.Right:
                    newX++;
                    break;
            }

            if (newX < 0)
            {
                newX = Snake.GridWidth - 1;
            }
            else if (newX >= Snake.GridWidth)
            {
                newX = 0;
            }

            if (newY < 0)
            {
                newY = Snake.GridHeight - 1;
            }
            else if (newY >= Snake.GridHeight)
            {
                newY = 0;
            }

            // Add a new piece to the front of the snake
            Pieces.Insert(0, new SnakePiece(newX, newY));

            // Remove the last piece of the snake
            Pieces.RemoveAt(Pieces.Count - 1);
        }

        public bool CheckSelfCollision()
        {
            //Checks for collisions
            if (Pieces.Count < 5)
            {
                return false; //Under 5 pieces, no chance of collision
            }
            SnakePiece head = Pieces[0];
            for (int i = 1; i < Pieces.Count; i++)
            {
                SnakePiece piece = Pieces[i];
                if (head.X == Pieces[i].X && head.Y == Pieces[i].Y)
                {
                    return true; //Collision found.
                }
            }
            return false; //No Collision.
        }

        public bool CheckSnakeCollision(SnakeEntity otherSnake)
        {

            if (Pieces.Count < 4 || otherSnake.Pieces.Count < 4)
            {
                return false;
            }
            SnakePiece head = Pieces[0];
            for (int i = 0; i < otherSnake.Pieces.Count; i++)
            {
                SnakePiece piece = otherSnake.Pieces[i];
                if (head.X == piece.X && head.Y == piece.Y)
                {
                    return true;
                }
            }
            return false;
           
        }

        public bool CheckFoodCollision(int foodX, int foodY)
        {
            if (Pieces.Count == 0)
            {
                return false;
            }

            if (Pieces[0].X == foodX && Pieces[0].Y == foodY)
            {
                return true;
            }


            return false;
        }

        public void AddPoints(int points)
        {
            //Adds points to the player
            this.Points += points;
        }
        
        public void PlayerDeath()
        {
            //Cleans the snake pieces from the list
            Pieces.Clear();
        }

        public void AddPiece(int pieces)
        {

            for (int i = 0; i < pieces; i++)
            {
                Pieces.Add(new SnakePiece(10 + i, 10, 1));
            }
            
        }

        public void RemoveLastPiece()
        {
            if (Pieces.Count > 0)
            {
                Pieces.RemoveAt(Pieces.Count - 1);
            }
        }
    }
}


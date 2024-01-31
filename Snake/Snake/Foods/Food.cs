using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public abstract class Food
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Points { get; private set; }
        public int Length { get; private set; }
        public Brush Color { get; private set; }


        public Food(int x, int y, int points, int length, Brush color)
        {
            X = x;
            Y = y;
            Points = points;
            Length = length;
            Color = color; 

        }

        public void Draw(Graphics g, int tileSize = 10)
        {
             g.FillRectangle(Color, X * tileSize, Y * tileSize, tileSize, tileSize);
        }

        

    }

}

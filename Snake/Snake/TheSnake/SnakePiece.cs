using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class SnakePiece
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int Player { get; set; }


        public SnakePiece(int x, int y, int player = 0)
        {
            this.X = x;
            this.Y = y;
            this.Player = player;
        }

    }
}

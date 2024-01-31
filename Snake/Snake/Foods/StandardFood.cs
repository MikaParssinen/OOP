using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    public class StandardFood : Food
    {
        public StandardFood(int x, int y) : base(x, y, 1, 1, Brushes.Green)
        {
        }

    }
}

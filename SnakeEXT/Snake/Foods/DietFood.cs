using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class DietFood : Food
    {
        public DietFood(int x, int y) : base(x, y, -1, -1, Brushes.Purple)
        {

        }
    }
}

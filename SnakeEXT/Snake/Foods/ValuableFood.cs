using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ValuableFood : Food
    {
        public ValuableFood(int x, int y) : base(x, y, 5, 2, Brushes.Gold)
        {

        }
    }

}

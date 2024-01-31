using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class ScoreEventArgs : EventArgs
    {
        public int Player1Score { get; set; }

        public int Player2Score { get; set; }

     
    }
}

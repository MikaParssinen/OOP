using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;




namespace Bounce
{
    interface Obstacle
    {
        void Collision(Ball ball);
        void Draw(Graphics g);

    }
}

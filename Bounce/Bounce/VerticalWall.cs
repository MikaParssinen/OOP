using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bounce
{
    public class VerticalWall : Wall
    {

      
       public VerticalWall(int x, int y, int width, int height)
       {
            base.pen = new Pen(Color.Yellow, 3);
            base.position = new PointF(x, y);
            base.size = new PointF(width, height);
       }

       public override void SpeedModifier(Ball ball)
       {
            ball.SetSpeed(new PointF(-ball.GetSpeed().X, ball.GetSpeed().Y));
       }
        

    }
}

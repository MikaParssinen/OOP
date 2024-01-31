using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    public class RedBox : Box
    {
        
            public RedBox(int x, int y, int width, int height)
            {
                base.pen = new Pen(Color.Red, 3);
                base.position = new PointF(x, y);
                base.size = new PointF(width, height);
            }


            public override void SpeedModifier(Ball ball)
            {
            
                if (ball.GetSpeed().X < 8 && ball.GetSpeed().Y < 8)
                {
                ball.SetSpeed(new PointF(ball.GetSpeed().X * 1.1f, ball.GetSpeed().Y * 1.1f));
                }
            }

        }



    
}

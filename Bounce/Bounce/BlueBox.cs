using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bounce
{
    public class BlueBox : Box
    {
        public BlueBox(int x, int y, int width, int height)
        {
            base.pen = new Pen(Color.Blue, 3);
            base.position = new PointF(x, y);
            base.size = new PointF(width, height);
        }
        

        public override void SpeedModifier(Ball ball)
        {

            if (ball.GetSpeed().X > 0.8f && ball.GetSpeed().Y > 0.8f)
            {

                ball.SetSpeed(new PointF(ball.GetSpeed().X * 0.2f, ball.GetSpeed().Y * 0.2f));
            }
   
        }

    }
}

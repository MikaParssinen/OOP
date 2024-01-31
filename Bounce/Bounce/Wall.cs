using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Bounce
{
    public abstract class Wall : Obstacle
    {
        protected Pen pen;
        protected PointF position;
        protected PointF size;

        public void Collision(Ball ball)
        {
            var rect = new RectangleF(position.X, position.Y, size.X, size.Y);

            var BallPositionX = ball.GetPosition().X;
            var BallPositionY = ball.GetPosition().Y;
            var BallRadius = ball.GetRadius();
            var Rectangle2 = new RectangleF(BallPositionX - BallRadius, BallPositionY - BallRadius, 2 * BallRadius, 2 * BallRadius);

            if (rect.IntersectsWith(Rectangle2))
            {
                SpeedModifier(ball);
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawRectangle(pen, position.X, position.Y, size.X, size.Y);
        }

        public abstract void SpeedModifier(Ball ball);
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Bounce
{
	public class Engine
	{
		MainForm Form = new MainForm();
		Timer Timer = new Timer();
		List<Ball> Balls = new List<Ball>();
		Random Random = new Random();

        List<Obstacle> obstacles = new List<Obstacle>();
        public void Run()
		{



			//Adding new slowing blue boxes
			obstacles.Add(new BlueBox(100, 400, 100, 100));
            obstacles.Add(new BlueBox(400, 60, 120, 100));
            
            //Adding new red boxes
            obstacles.Add(new RedBox(100, 100, 100, 100));
            obstacles.Add(new RedBox(500, 340, 150, 80));

            //Adding new horizontal wall
            obstacles.Add(new HorizontalWall(200, 20, 300, 1));
            obstacles.Add(new HorizontalWall(400, 550, 350, 1));
			obstacles.Add(new HorizontalWall(200, 100, 330, 1));

            //Adding new vertical wall
            obstacles.Add(new VerticalWall(20, 200, 1, 350));
            obstacles.Add(new VerticalWall(750, 300, 1, 350));

			


            Form.Paint += Draw;
			Timer.Tick += TimerEventHandler;
			Timer.Interval = 1000/25;
			Timer.Start();


			Application.Run(Form);
		}

		void TimerEventHandler(Object obj, EventArgs args)
		{
			if (Random.Next(100) < 25)
            {
				var ball = new Ball(400, 300, 10);
				Balls.Add(ball);
			}

			foreach (var ball in Balls)
			{
				ball.Move();
				foreach (var obstacle in obstacles) obstacle.Collision(ball);
			}


			
			Form.Refresh();
		}

		void Draw(Object obj, PaintEventArgs args)
		{
			foreach (var ball in Balls) ball.Draw(args.Graphics);

			foreach (var obstacle in obstacles) obstacle.Draw(args.Graphics);
		}

	}
}

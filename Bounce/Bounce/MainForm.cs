using System;
using System.Windows.Forms;


namespace Bounce
{
	public class MainForm : Form
	{
		public MainForm() : base()
		{
			Text = "Bounce!";
            BackColor = System.Drawing.Color.Black;
            Width = 800;
			Height = 600;
			DoubleBuffered = true;
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(318, 274);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}

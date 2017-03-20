using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 키보드조작
{
	public partial class Form1 : Form
	{
		bool left, right, up, down;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Left)
			{
				left = true;
			}
			if(e.KeyCode == Keys.Right)
			{
				right = true;
			}
			if(e.KeyCode == Keys.Up)
			{
				up = true;
			}
			if(e.KeyCode == Keys.Down)
			{
				down = true;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Left)
			{
				left = false;
			}
			if (e.KeyCode == Keys.Right)
			{
				right = false;
			}
			if (e.KeyCode == Keys.Up)
			{
				up = false;
			}
			if (e.KeyCode == Keys.Down)
			{
				down = false;
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (left)
			{
				textBox1.Left--;
			}
			if (right)
			{
				textBox1.Left++;
			}
			if (up)
			{
				textBox1.Top--;
			}
			if (down)
			{
				textBox1.Top++;
			}
		}
	}
}
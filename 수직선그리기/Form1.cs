using System;
using System.Drawing;
using System.Windows.Forms;

namespace 수직선그리기
{
	public partial class Form1 : Form
	{
		int y;
		Bitmap _도화지;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// 폼과 동일한 크기의 도화지를 만든다.
			_도화지 = new Bitmap(this.Width, this.Height);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// 폼에 도화지를 통째로 복사한다.
			e.Graphics.DrawImage(_도화지, 0, 0);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			/*********************************************
			 * 도화지에 수직선 그리기
			 *********************************************/
			// 도화지(Bitmap 객체)에 그림을 그리기 위해서는
			// Graphics 객체를 가져와야 한다.
			Graphics g = Graphics.FromImage(_도화지);
			g.Clear(Color.White); // 도화지를 흰색으로 초기화.

			for (int x = 0; x < 100; x++) // 도화지에 수직선 100개 그리기
			{
				g.DrawLine(
					Pens.Black,
					x * 2,  // 시작점 x좌표
					y,      // 시작점 y좌표
					x * 2,  // 끝점 x
					y + 50  // 끝점 y
				);
			}
			y++;

			Invalidate(); // OnPaint() 강제호출
		}
	}
}

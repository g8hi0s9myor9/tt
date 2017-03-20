using System;
using System.Drawing;
using System.Windows.Forms;

// 코드24 이후 달라진 점.
// 54번라인 _grid -> _temp_grid

namespace 테트리스
{
	public partial class Form1 : Form
	{
		Tetris _tt;
		Bitmap _buff; // 도화지
		bool _left, _right, _up, _down;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			_tt = new Tetris();
			int[,] blk =
			{
				{1, 1 },
				{1, 1 }
			};
			_tt.add_block(blk, 5, 0);

			// 도화지 객체 생성
			_buff = new Bitmap(this.Width, this.Height);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			// 도화지를 통째로 폼에 복사
			e.Graphics.DrawImage(_buff, 0, 0);
		}

		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// 아무런 코드도 입력하지 않았으므로
			// 폼의 배경을 회색으로 덧칠하는 기본 작업은 더이상
			// 이루어지지 않는다.
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			int x = 0, y = 0;
			if (_left) x--;
			if (_right) x++;
			if (_up) y--;
			if (_down) y++;
			_tt._temp_grid = _tt.shift(_tt._temp_grid, x, y);

			/*************************************************
			 * 도화지에 블록을 그린다.
			 *************************************************/
			// 도화지에 그림을 그리려면 Graphics 객체를 가져와야 한다.
			Graphics g = Graphics.FromImage(_buff);
			g.Clear(Color.White); // 도화지를 회색으로 초기화한다.
			_tt.draw(g); // 도화지에 블록을 그린다.

			Invalidate(); // OnPaint() 강제호출
		}

		#region Form1_KeyDown(), Form1_KeyUp()

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					_left = true;
					break;
				case Keys.Right:
					_right = true;
					break;
				case Keys.Up:
					_up = true;
					break;
				case Keys.Down:
					_down = true;
					break;
			}
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Left:
					_left = false;
					break;
				case Keys.Right:
					_right = false;
					break;
				case Keys.Up:
					_up = false;
					break;
				case Keys.Down:
					_down = false;
					break;
			}
		}

		#endregion
	}
}
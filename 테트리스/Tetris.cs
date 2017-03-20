﻿using System;
using System.Drawing;

// 코드24 이후 달라진 점.
// 임시배열 추가.
// add_block() 수정.
// clear(), colision() 추가.

namespace 테트리스
{
	class Tetris
	{
		// 메인배열
		public int[,] _grid = new int[20, 10];
		// 임시배열
		public int[,] _temp_grid = new int[20, 10];
		public int _blockSize = 20;

		public Tetris()
		{
			
		}

		public bool add_block(int[,] blk, int x, int y)
		{
			// ---------------------------------------
			// 임시배열에 블록 blk를 일단 삽입한다.
			// ---------------------------------------
			int rows = blk.GetLength(0);
			int cols = blk.GetLength(1);
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					// 임시배열에 blk를 삽입한다.
					_temp_grid[r+y, c+x] = blk[r, c];
				}
			}
			// ---------------------------------------
			// 임시배열과 _grid가 충돌하면 블록삽입 작업은 실패다.
			if (colision(_temp_grid, _grid))
			{
				// 임시배열에 삽입했던 blk는 충돌한다.
				// 그래서 임시배열을 0으로 클리어시킴으로써
				// 삽입했던 blk를 없애버린다.
				clear(_temp_grid, 0);
				return false;
			}
			else
			{
				// 충돌이 아니면 blk를 삽입한 임시배열을 그대로 둔 채
				// 메소드를 종료한다.
				return true;
			}
		}

		void clear(int[,] arr, int value)
		{
			// 배열 arr의 모든 값을 value로 덮어써버린다.
			for (int r = 0; r < arr.GetLength(0); r++)
			{
				for (int c = 0; c < arr.GetLength(1); c++)
				{
					arr[r, c] = value;
				}
			}
		}

		bool colision(int[,] arr1, int[,] arr2)
		{
			int rows = arr1.GetLength(0); // 행 크기
			int cols = arr1.GetLength(1); // 열 크기

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					// 둘 다 0보다 크면(1이면)
					if (arr1[r,c] > 0 && arr2[r,c] > 0)
					{
						return true; // 충돌
					}
				}
			}

			return false; // 충돌아님
		}

		#region shift(), sum(), draw()

		public int[,] shift(int[,] grid, int x, int y)
		{
			int sum_grid = sum(grid); // 1의 갯수 세기.

			int rows = grid.GetLength(0); // 행 갯수
			int cols = grid.GetLength(1); // 열 갯수
										  // grid와 똑같은 크기의 배열 생성
			int[,] clone = new int[rows, cols];

			for (int r = 0; r < rows; r++)
			{
				if (r + y < 0 || r + y >= rows) continue;

				for (int c = 0; c < cols; c++)
				{
					if (c + x < 0 || c + x >= cols) continue;

					// 매개변수 x, y만큼 건너뛴 곳에 복사한다.
					clone[r + y, c + x] = grid[r, c];
				}
			}

			int sum_clone = sum(clone); // 1의 갯수 세기.
			if (sum_grid == sum_clone) return clone; // 변함 없으면 shift 성공.
			else return grid; // 변했으면 실패. 원본배열 grid를 그냥 반환한다.
		}

		int sum(int[,] arr)
		{
			int rows = arr.GetLength(0); // 행 갯수
			int cols = arr.GetLength(1); // 열 갯수
			int i = 0;

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					i += arr[r, c];
				}
			}

			return i;
		}

		public void draw(Graphics g)
		{
			int rows = _grid.GetLength(0); // 행 갯수
			int cols = _grid.GetLength(1); // 열 갯수

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					if (_grid[r, c] != 0)
					{
						g.FillRectangle(
							Brushes.Black,
							c * _blockSize, // x좌표
							r * _blockSize, // y좌표
							_blockSize,     // 너비
							_blockSize      // 높이
						);
					}
					else
					{
						g.DrawRectangle(
							Pens.Black,
							c * _blockSize, // x좌표
							r * _blockSize, // y좌표
							_blockSize,     // 너비
							_blockSize      // 높이
						);
					}
				}
			}
		}
		
		#endregion
	}
}

//int[,] combine(int[,] arr1, int[,] arr2)
//{
//	// 0, 0 -> 0
//	// 1, 0 -> 1
//	// 0, 1 -> 1
//	// 1, 1 -> 1
//	int rows = arr1.GetLength(0); // 행 크기
//	int cols = arr1.GetLength(1); // 열 크기
//	int[,] result = new int[rows, cols];

//	for (int r = 0; r < rows; r++)
//	{
//		for (int c = 0; c < cols; c++)
//		{
//			if (arr1[r, c] == 0 && arr2[r, c] == 0)
//			{
//				result[r, c] = 0;
//			}
//			else result[r, c] = 1;
//		}
//	}

//	return result;
//}
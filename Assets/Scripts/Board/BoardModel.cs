using System.Collections;
using System.Collections.Generic;

using GOL.Configuration;
using GOL.Board.Cell;
using UnityEngine;

namespace GOL.Board
{
    public class BoardModel
    {
        private BoardConfigData _boardConfigData;
        private CellModel[,] _board;

		public BoardModel(BoardConfigData boardConfigData, CellModel[,] cellModels)
        {
			_boardConfigData = boardConfigData;
			_board = cellModels;
        }

		public void CheckCellState()
		{
			for (int column = 0; column < _boardConfigData.BoardSize.x; column++)
			{
				for (int row = 0; row < _boardConfigData.BoardSize.y; row++)
				{
					List<CellModel> neighbours = new List<CellModel>();

					for (int x = -1; x <= 1; x++)
					{
						for (int y = -1; y <= 1; y++)
						{
							if (!(x == 0 && y == 0))
							{
								int ncolumn = column + x;
								int nrow = row + y;

								if (ncolumn >= 0 &&
									ncolumn < _board.GetLength(0) &&
									nrow >= 0 &&
									nrow < _board.GetLength(1))
								{
									neighbours.Add(_board[ncolumn, nrow]);
								}
							}
						}
					}

					_board[column, row].CheckNextState(neighbours);

				}
			}
		}

		public void UpdateCellState()
		{
			foreach (CellModel cell in _board)
			{
				cell.UpdateCurrentState();
			}
		}

		public void ResetCells()
		{
			foreach(CellModel cell in _board)
			{
				cell.Reset();
			}
		}


	}
}

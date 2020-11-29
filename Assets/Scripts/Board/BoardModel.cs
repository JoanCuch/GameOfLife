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

		private List<CellModel> _liveList;

		public BoardModel(BoardConfigData boardConfigData, CellModel[,] cellModels, List<CellModel> liveList)
        {
			_boardConfigData = boardConfigData;
			_board = cellModels;
			_liveList = liveList;
        }

		public void CheckCellState()
		{
			List<CellModel> allNeighbours = new List<CellModel>();
			
			foreach(CellModel liveCell in _liveList)
			{
				List<CellModel> cellNeighbours = GetNeighbours(liveCell, allNeighbours);
				liveCell.CheckNextState(cellNeighbours);
				Debug.Log("live cell checked");
			}

			foreach(CellModel deadCell in allNeighbours)
			{
				List<CellModel> cellNeighbours = GetNeighbours(deadCell, null);
				deadCell.CheckNextState(cellNeighbours);
				Debug.Log("dead cell checked");

			}
		}

		private List<CellModel> GetNeighbours(CellModel cell, List<CellModel> allNeighboursList)
		{
			List<CellModel> cellNeighbours = new List<CellModel>();

			for (int x = -1; x <= 1; x++)
			{
				for (int y = -1; y <= 1; y++)
				{
					if (!(x == 0 && y == 0))
					{
						int ncolumn = cell.Position.x + x;
						int nrow = cell.Position.y + y;

						if (ncolumn >= 0 &&
							ncolumn < _board.GetLength(0) &&
							nrow >= 0 &&
							nrow < _board.GetLength(1))
						{
							CellModel neigh = _board[ncolumn, nrow];
							cellNeighbours.Add(neigh);

							if(neigh.CurrentState.Value != CellStatesData.live &&
								allNeighboursList != null &&
								!allNeighboursList.Contains(neigh))
							{
								allNeighboursList.Add(neigh);
							}
						}
					}
				}
			}
			return cellNeighbours;
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

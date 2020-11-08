using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Board: MonoBehaviour
{
	//[SerializeField] private List<Cell> cellList;

	private GridLayoutGroup gridLayout;

	[SerializeField] private Cell[,] board;
	[SerializeField] private int boardRows;
	[SerializeField] private int boardColumns;
	[SerializeField] private GameObject cellPrefab;

	[SerializeField] private float minScale;
	[SerializeField] private float maxScale;
	[SerializeField] private Scrollbar sizeScrollBar;
	[SerializeField] private float scaleMultiplier;

	public void Initialize()
	{
		gridLayout = GetComponent<GridLayoutGroup>();
		gridLayout.constraintCount = boardColumns;

		Vector2 cellSize = Vector2.zero;
		cellSize.x = cellPrefab.GetComponent<RectTransform>().rect.width * cellPrefab.transform.localScale.x;
		cellSize.y = cellPrefab.GetComponent<RectTransform>().rect.height * cellPrefab.transform.localScale.y;

		gridLayout.cellSize = cellSize;

		board = new Cell[boardColumns, boardRows];

		for(int y= 0; y<boardRows; y++)
		{
			for(int x = 0; x < boardColumns; x++)
			{
				GameObject newCell = Instantiate(cellPrefab, this.transform);
				board[x, y] = newCell.GetComponent<Cell>();
				board[x, y].Initialize();
				board[x, y].localPosition = new Vector2(x, y);
			}
		}

		ChangeBoardScale();
	}

	public void CheckCellState()
	{

		for (int column = 0; column < boardColumns; column++)
		{
			for (int row = 0; row < boardRows; row++)
			{
				List<Cell> neighbours = new List<Cell>();

				for (int x = -1; x <= 1; x++)
				{
					for (int y = -1; y <= 1; y++)
					{
						if (!(x == 0 && y == 0))
						{
							int ncolumn = column + x;
							int nrow = row + y;
							
							if (ncolumn >= 0 &&
								ncolumn < board.GetLength(0) &&
								nrow >= 0 &&
								nrow < board.GetLength(1))
							{
								neighbours.Add(board[ncolumn, nrow]);
							}
						}
					}
				}

				board[column, row].CheckNextState(neighbours);

			}
		}
	}

	public void UpdateCellState()
	{
		foreach(Cell cell in board)
		{
			cell.UpdateCurrentState();
		}
	}

	public void ChangeBoardScale()
	{
		float scale = Mathf.Lerp(minScale, maxScale, sizeScrollBar.value) * scaleMultiplier;

		Vector3 newScale = new Vector3(scale, scale, 1);
		
		transform.localScale = newScale;
	}
}

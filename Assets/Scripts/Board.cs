using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class Board: MonoBehaviour
{
	[SerializeField] private List<Cell> cellList;

	[SerializeField] private GridLayoutGroup gridLayout;


	public void Initialize()
	{
		GiveAllCellsHisPosition();
	}

	private void GiveAllCellsHisPosition()
	{
		float rowNumber = gridLayout.constraintCount;
		Debug.Log(rowNumber);
		for (int idx = 1; idx <= cellList.Count; idx++)
		{
			int x = (int)Mathf.Floor(idx % rowNumber);
			if (x == 0) x = 5;
			x--;

			int y = (int)Mathf.Ceil(idx / rowNumber)-1;

			Vector2Int localPosition = new Vector2Int(x, y);

			cellList[idx-1].Initialize(localPosition);
		}
		Debug.Log(cellList.Count);
	}

	public void CheckCellState()
	{
		foreach(Cell cell in cellList)
		{
			List<Cell> neighbours = new List<Cell>();
			cell.checkState(neighbours);
		}
	}

	public void UpdateCellState()
	{
		foreach(Cell cell in cellList)
		{
			cell.updateState();
		}
	}
}

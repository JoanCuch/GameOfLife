using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CellController
{
	 private Tilemap tilemap;

	private List<Cell> cellList;

	public CellController(Tilemap _tilemap)
	{
		tilemap = _tilemap;
		cellList = new List<Cell>();
		GiveAllCellsHisPosition();
	}

	private void GiveAllCellsHisPosition()
	{
		Debug.Log(tilemap.cellBounds.xMin + " " + tilemap.cellBounds.xMax);
		Debug.Log(tilemap.cellBounds.yMin + " " + tilemap.cellBounds.yMax);
		for (int x = tilemap.cellBounds.xMin; x < tilemap.cellBounds.xMax; x++)
		{	
			for(int y = tilemap.cellBounds.yMin; y < tilemap.cellBounds.yMax; y++)
			{
				Vector3Int localPosition = new Vector3Int(x, y, tilemap.cellBounds.z);
				Debug.Log(localPosition);
				if (tilemap.HasTile(localPosition))
				{
					Debug.Log("new cell: " + localPosition);
					Cell cell = (Cell)tilemap.GetTile(localPosition);
					cell.Initialize(localPosition);
					cellList.Add(cell);
				}
			}
		}
		Debug.Log(cellList.Count);
	}

	public void CheckCellState()
	{
		Debug.Log("check state");
		foreach(Cell cell in cellList)
		{
			Vector3Int cellPosition = cell.GetLocalPosition();
			List<Cell> neighbours = new List<Cell>();

			for(int x=-1; x<=1; x++)
			{
				for(int y=-1; y<=1; y++)
				{
					Vector3Int neighbourPosition = new Vector3Int(cellPosition.x + x, cellPosition.y + y, cellPosition.z);
					if (tilemap.HasTile(neighbourPosition))
					{
						Cell neighbour = (Cell)tilemap.GetTile(neighbourPosition);
						neighbours.Add(neighbour);
					}
				}
			}
			cell.checkState(neighbours);
		}
	}

	public void UpdateCellState()
	{
		Debug.Log("update state");
		foreach(Cell cell in cellList)
		{
			cell.updateState();
			tilemap.RefreshTile(cell.GetLocalPosition());
		}
	}
}

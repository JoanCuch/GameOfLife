using GOL.Board;
using GOL.Board.Cell;
using GOL.Reactive;
using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveListCommand : ICommand
{
	private List<CellModel> _liveList;
	private CellModel _cellModel;


	public LiveListCommand(CellModel cellModel, List<CellModel> liveList)
	{
		_liveList = liveList;
		_cellModel = cellModel;
	}

	public void Execute(CellStatesData cellStateData)
	{
		Execute();
	}

	public void Execute()
	{		
		if (_cellModel.CurrentState.Value == CellStatesData.live)
		{
			_liveList.Add(_cellModel);
			
		}
		else if (_cellModel.CurrentState.Value == CellStatesData.dead)
		{
			_liveList.Remove(_cellModel);
		}
		else
		{
			Debug.LogError("A cell is in a incorrect state: " + _cellModel.CurrentState.Value);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Reactive;
using GOL.Board;

public class ResetBoardCommand : ICommand
{
	private BoardModel _model;

	public ResetBoardCommand(BoardModel model)
	{
		_model = model;
	}

    public void Execute()
	{
		_model.ResetCells();
	}
}

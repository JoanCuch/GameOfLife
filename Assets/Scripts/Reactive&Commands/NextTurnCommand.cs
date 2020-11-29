using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Reactive;
using GOL.Board;

public class NextTurnCommand : ICommand
{
	private BoardModel _model;

	public NextTurnCommand(BoardModel model)
	{
		_model = model;
	}

	public void Execute()
	{
		_model.CheckCellState();
		_model.UpdateCellState();
	}
}

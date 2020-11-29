using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Board;


namespace GOL.Reactive
{
	public class BoardCommandsManager
	{
		public readonly ResetBoardCommand ResetBoardCommand;
		public readonly NextTurnCommand NextTurnCommand;

		public BoardCommandsManager(BoardModel boardModel)
		{
			ResetBoardCommand = new ResetBoardCommand(boardModel);
			NextTurnCommand = new NextTurnCommand(boardModel);
		}
	}
}

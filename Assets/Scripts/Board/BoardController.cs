using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.GUI;

namespace GOL.Board
{
    public class BoardController
    {
        private BoardModel _model;
        private BoardView _view;
        private Timer _timer;

        public BoardController(BoardModel model, BoardView view, Timer timer, GUIModel guiModel)
        {
            _model = model;
            _view = view;
            _timer = timer;
                     
            _timer.SubscribeToAlarm(NextTurn);

            guiModel.SubscribeToNextTurnEvent(NextTurn);
            guiModel.SubscribeToResetEvent(Reset);

            guiModel.Play.Subscribe(Play);
            guiModel.TimeScale.Subscribe(ChangeStandardDelay);
            guiModel.SizeScale.Subscribe(ChangeBoardSize);    
        }

        public void Play(bool isOnPLay)
        {
            _timer.AutomaticTurn();
        }

        public void NextTurn()
        {
            _model.CheckCellState();
            _model.UpdateCellState();
        }

        private void ChangeStandardDelay(float normalizedDelay)
        {
            _timer.ChangeStandardDelay(normalizedDelay);
        }

        private void ChangeBoardSize(float normalizedSize)
		{
            _view.UpdateBoardScale(normalizedSize);
		}

        private void Reset()
		{
            _model.ResetCells();
		}
    }
}

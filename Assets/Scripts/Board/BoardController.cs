using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOL.Board
{
    public class BoardController
    {
        private BoardModel _model;
        private BoardView _view;
        private Timer _timer;

        public BoardController(BoardModel model, BoardView view, Timer timer)
        {
            _model = model;
            _view = view;
            _timer = timer;
                     
            view.Setup(_model.BoardConfigData);
            view.SubscribeToPlayEvent(Play);
            view.SubscribeToNextTurnEvent(NextTurn);
            view.SubscribeToTimeScaleEvent(ChangeStandardDelay);

            timer.Setup(_model.BoardConfigData);
            timer.SubscribeToAlarm(NextTurn);         
        }

        public void Play()
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
    }
}

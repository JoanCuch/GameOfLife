using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.GUI;
using GOL.Reactive;

namespace GOL.Board
{
    public class BoardController
    {
        private BoardModel _model;
        private BoardView _view;
        private Timer _timer;

        public BoardController(BoardModel model, BoardView view, Timer timer, GUIModel guiModel, GUIView guiView)
        {
            _model = model;
            _view = view;
            _timer = timer;

            NextTurnCommand nextTurnCommand = new NextTurnCommand(model);

            _timer.Subscribe(nextTurnCommand.Execute);

            guiModel.Play.Subscribe(Play);
            guiModel.TimeScale.Subscribe(ChangeStandardDelay);
            guiModel.SizeScale.Subscribe(ChangeBoardSize);

            guiView.SubscribeToResetButton(new ResetBoardCommand(model).Execute);
            guiView.SubscribeToNextTurnButton(nextTurnCommand.Execute);
        }

        public void Play(bool isOnPLay)
        {
            _timer.AutomaticTurn();
        }

        private void ChangeStandardDelay(float normalizedDelay)
        {
            _timer.ChangeStandardDelay(normalizedDelay);
        }

        private void ChangeBoardSize(float normalizedSize)
		{
            _view.UpdateBoardScale(normalizedSize);
		}
    }
}

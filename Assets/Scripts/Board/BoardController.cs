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

        public BoardController(BoardModel model, BoardView view, Timer timer, GUIModel guiModel, GUIView guiView, BoardCommandsManager commandsManager)
        {
            _model = model;
            _view = view;
            _timer = timer;

            _timer.Subscribe(commandsManager.NextTurnCommand.Execute);

            guiModel.Play.Subscribe(Play);
            guiModel.TimeScale.Subscribe(ChangeStandardDelay);
            guiModel.SizeScale.Subscribe(ChangeBoardSize);

            guiView.SubscribeToResetButton(commandsManager.ResetBoardCommand.Execute);
            guiView.SubscribeToNextTurnButton(commandsManager.NextTurnCommand.Execute);
        }

        public void Play(bool isOnPlay)
        {
            _timer.SetLoop(isOnPlay);
        }

        private void ChangeStandardDelay(float normalizedDelay)
        {
            _timer.SetDelay(normalizedDelay);
        }

        private void ChangeBoardSize(float normalizedSize)
		{
            _view.UpdateBoardScale(normalizedSize);
		}
    }
}

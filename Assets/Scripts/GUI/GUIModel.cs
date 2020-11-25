using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GOL.Configuration;

namespace GOL.GUI {
    public class GUIModel
    {

        private UnityEvent<bool> _playEvent;
        private UnityEvent<string> _changePlayTextEvent;
        private UnityEvent<float> _timeScaleEvent;
        private UnityEvent<float> _sizeScaleEvent;
        private UnityEvent _nextTurnEvent;
        private UnityEvent _resetEvent;

        private bool _isOnPlay;
        private GUIConfigData _GUIConfigData;


        public GUIModel(GUIConfigData guiConfigData)
        {
            _isOnPlay = false;
            _GUIConfigData = guiConfigData;

            _playEvent = new UnityEvent<bool>();
            _changePlayTextEvent = new UnityEvent<string>();
            _timeScaleEvent = new UnityEvent<float>();
            _sizeScaleEvent = new UnityEvent<float>();
            _nextTurnEvent = new UnityEvent();
            _resetEvent = new UnityEvent();
        }

        public void ChangePlayState()
        {
            _isOnPlay = !_isOnPlay;
            _playEvent.Invoke(_isOnPlay);
            _changePlayTextEvent.Invoke(GetTextOfPLayButton());
        }
        public void ChangeTimeScale(float newScale)
        {
            _timeScaleEvent.Invoke(newScale);
        }
        public void ChangeSizeScale(float newScale)
		{
            _sizeScaleEvent.Invoke(newScale);
		}
        public void NextTurn()
        {
            if (!_isOnPlay)
            {
                _nextTurnEvent.Invoke();
            }
        }
        public void Reset()
		{
            _resetEvent.Invoke();
		}

        public void SubscribeToPlayEvent(UnityAction<bool> action) => _playEvent.AddListener(action);
        public void SubscribeToPlayTextEvent(UnityAction<string> action) => _changePlayTextEvent.AddListener(action);
        public void SubscribeToNextTurnEvent(UnityAction action) => _nextTurnEvent.AddListener(action);
        public void SubscribeToTimeScaleEvent(UnityAction<float> action) => _timeScaleEvent.AddListener(action);
        public void SubscribeToSizeScaleEvent(UnityAction<float> action) => _sizeScaleEvent.AddListener(action);
        public void SubscribeToResetEvent(UnityAction action) => _resetEvent.AddListener(action);

        public string GetTextOfPLayButton()
		{
			if (_isOnPlay)
			{
                return _GUIConfigData.PauseButtonString;
            }
			else
			{
                return _GUIConfigData.PlayButtonString;
			}            
		}


    } 
}

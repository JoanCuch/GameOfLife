using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GOL.Configuration;
using GOL.Reactive;

namespace GOL.GUI {
    public class GUIModel
    {
        public readonly ReactiveProperty<bool> Play;
        public readonly ReactiveProperty<string> PlayText;
        public readonly ReactiveProperty<float> TimeScale;
        public readonly ReactiveProperty<float> SizeScale;

        private UnityEvent _nextTurnEvent;
        private UnityEvent _resetEvent;

        private GUIConfigData _GUIConfigData;


        public GUIModel(GUIConfigData guiConfigData)
        {
            _GUIConfigData = guiConfigData;

            Play = new ReactiveProperty<bool>();
            PlayText = new ReactiveProperty<string>();
            TimeScale = new ReactiveProperty<float>();
            SizeScale = new ReactiveProperty<float>();

            _nextTurnEvent = new UnityEvent();
            _resetEvent = new UnityEvent();
        }

        public void InversePlayPause()
		{
            Play.Value = !Play.Value;
		}

        public void NextTurn()
        {
            if (!Play.Value)
            {
                _nextTurnEvent.Invoke();
            }
        }
        public void Reset()
		{
            _resetEvent.Invoke();
		}


        public void SubscribeToNextTurnEvent(UnityAction action) => _nextTurnEvent.AddListener(action);
        public void SubscribeToResetEvent(UnityAction action) => _resetEvent.AddListener(action);

        public string GetTextOfPLayButton()
		{
			if (Play.Value)
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

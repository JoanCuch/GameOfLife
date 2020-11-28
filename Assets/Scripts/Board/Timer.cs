using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using GOL.Configuration;
using UnityEngine.Events;

namespace GOL.Board
{

    public class Timer : MonoBehaviour
    {
        private BoardConfigData _boardConfigData;

        private bool _automatic;
        private float _currentDelay;
        private float _standardDelay;

        private UnityEvent _alarm;
    
        public void Setup(BoardConfigData boardConfigData)
        {
            _alarm = new UnityEvent();
            _automatic = false;
            _currentDelay = 0;
            _boardConfigData = boardConfigData;
            ChangeStandardDelay(_boardConfigData.TimerInitialDelay);
        }

        void Update()
        {
            if (_automatic)
            {
                _currentDelay += Time.deltaTime;

                if (_currentDelay >= _standardDelay)
                {
                    _currentDelay = 0;
                    _alarm.Invoke();
                }
            }
        }

        public void Subscribe(UnityAction action) => _alarm.AddListener(action);

        public void AutomaticTurn()
        {
            _automatic = !_automatic;
            _currentDelay = 0;
        }

        public void ChangeStandardDelay(float normalizedDelay)
        {
            _standardDelay = Mathf.Lerp(_boardConfigData.TimerMinDelay, _boardConfigData.TimerMaxDelay, normalizedDelay)
                * _boardConfigData.TimerDelayMultiplier;
        }

    }
}

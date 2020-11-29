using UnityEngine;
using UnityEngine.Events;
using GOL.Configuration;

namespace GOL.Board
{
    public class Timer : MonoBehaviour
    {
        private BoardConfigData _boardConfigData;

        private bool _loop;
        private float _timeCounter;
        private float _alarmDelay;

        private UnityEvent _alarm;
    
        public void Setup(BoardConfigData boardConfigData)
        {
            _alarm = new UnityEvent();
            _loop = false;
            _timeCounter = 0;
            _boardConfigData = boardConfigData;
            SetDelay(_boardConfigData.TimerInitialDelay);
        }

        void Update()
        {
            if (_loop)
            {
                _timeCounter += Time.deltaTime;

                if (_timeCounter >= _alarmDelay)
                {
                    _timeCounter = 0;
                    _alarm.Invoke();
                }
            }
        }

        public void Subscribe(UnityAction action) => _alarm.AddListener(action);

        public void SetLoop(bool loop)
        {
            _loop = loop;
            _timeCounter = 0;
        }

        public void SetDelay(float normalizedDelay)
        {
            _alarmDelay = Mathf.Lerp(_boardConfigData.TimerMinDelay, _boardConfigData.TimerMaxDelay, normalizedDelay)
                * _boardConfigData.TimerDelayMultiplier;
        }
    }
}

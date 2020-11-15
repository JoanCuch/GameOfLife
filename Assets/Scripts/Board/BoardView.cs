using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Dynamic;

namespace GOL.Board
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _nextTurnButton;
        [SerializeField] private Scrollbar _sizeScrollBar;
        [SerializeField] private Scrollbar _timeScrollBar;

        [SerializeField] private GridLayoutGroup _gridLayout;

        private BoardConfigData _boardConfigData;

        public void Setup(BoardConfigData _boardConfigData)
        {
            this._boardConfigData = _boardConfigData;
            _gridLayout.constraintCount = this._boardConfigData.BoardSize.x;

            _sizeScrollBar.onValueChanged.AddListener(UpdateBoardScale);
            UpdateBoardScale(_sizeScrollBar.value);
        }

        public void SubscribeToPlayEvent(UnityAction action) => _playButton.onClick.AddListener(action);
        public void SubscribeToNextTurnEvent(UnityAction action) => _nextTurnButton.onClick.AddListener(action);
        public void SubscribeToTimeScaleEvent(UnityAction<float> action) => _timeScrollBar.onValueChanged.AddListener(action);

        public void UpdateBoardScale(float scaleNumber)
        {
            float scale = Mathf.Lerp(
                _boardConfigData.BoardMinScale,
                _boardConfigData.BoardMaxScale,
                scaleNumber
                ) * _boardConfigData.BoardScaleMultiplier;

            Vector3 newScale = new Vector3(scale, scale, 1);

            transform.localScale = newScale;
        }

    }
}

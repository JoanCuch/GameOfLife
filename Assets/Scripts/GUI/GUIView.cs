using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GOL.Reactive;


namespace GOL.GUI
{
    public class GUIView : MonoBehaviour
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _nextTurnButton;
        [SerializeField] private Scrollbar _sizeScrollBar;
        [SerializeField] private Scrollbar _timeScrollBar;
        [SerializeField] private Text _playButtonText;
        [SerializeField] private Button _resetButton;

        public void SubscribeToPlayButton(UnityAction action) => _playButton.onClick.AddListener(action);
        public void SubscribeToNextTurnButton(UnityAction action) => _nextTurnButton.onClick.AddListener(action);
        public void SubscribeToTimeScaleButton(UnityAction<float> action) => _timeScrollBar.onValueChanged.AddListener(action);
        public void SubscribeToSizeScaleButton(UnityAction<float> action) => _sizeScrollBar.onValueChanged.AddListener(action);
        public void SubscribeToResetButton(UnityAction action) => _resetButton.onClick.AddListener(action);


        public void SetPlayButtonText(string newText)
		{
            _playButtonText.text = newText;
		}

    }
}

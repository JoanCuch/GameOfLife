using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GOL.Configuration
{
    [CreateAssetMenu(menuName = "Config/BoardConfigData", fileName = "BoardConfigData")]
    public class BoardConfigData : ScriptableObject
    {
        [SerializeField] private int _mouseClickButton;

        [SerializeField] private Vector2Int _boardSize;
        [SerializeField] private float _boardMinScale;
        [SerializeField] private float _boardMaxScale;
        [SerializeField] private float _boardScaleMultiplier;
        [SerializeField] private float _boardInitialScale;

        [SerializeField] private float _timerMinDelay;
        [SerializeField] private float _timerMaxDelay;
        [SerializeField] private float _timerDelayMultiplier;
        [SerializeField] private float _timerInitialDelay;

        [SerializeField] private Color _liveColor;
        [SerializeField] private Color _deadColor;
        [SerializeField] private int _minNeighboursToLife;
        [SerializeField] private int _maxNeighboursToLife;
        [SerializeField] private int _minNeighbousToBorn;

        [SerializeField] private float _boardLerping;
        [SerializeField] private float _minDistanceToConsiderAsDragging;
        [SerializeField] private int _buttonsLayer;


        public int MouseClickButton => _mouseClickButton;

        public Vector2Int BoardSize => _boardSize;
        public float BoardMinScale => _boardMinScale;
        public float BoardMaxScale => _boardMaxScale;
        public float BoardScaleMultiplier => _boardScaleMultiplier;

        public float TimerMinDelay => _timerMinDelay;
        public float TimerMaxDelay => _timerMaxDelay;
        public float TimerDelayMultiplier => _timerDelayMultiplier;
        public float TimerInitialDelay => _timerInitialDelay;

        public Color LiveColor => _liveColor;
        public Color DeadColor => _deadColor;
        public int MinNeighboursToLife => _minNeighboursToLife;
        public int MaxNeighboursToLife => _maxNeighboursToLife;
        public int MinNeighboursToBorn => _minNeighbousToBorn;

        public float BoardLerping => _boardLerping;
        public int ButtonsLayer => _buttonsLayer;
        public float MinDistanceToConsiderDragging => _minDistanceToConsiderAsDragging;

        

        
    }
}

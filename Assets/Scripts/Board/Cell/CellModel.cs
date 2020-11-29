using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;
using GOL.Reactive;

namespace GOL.Board.Cell
{
    public class CellModel
    {
        private BoardConfigData _boardConfigData;
        private CellStatesData _currentState;
        private CellStatesData _nextState;
        public readonly ReactiveProperty<CellStatesData> UpdatedState;
        private bool _ableToChange;

        public BoardConfigData BoardConfigData => _boardConfigData;

        public CellModel(BoardConfigData _boardConfigData)
        {
            this._boardConfigData = _boardConfigData;
            _currentState = CellStatesData.dead;
            _nextState = CellStatesData.dead;

            UpdatedState = new ReactiveProperty<CellStatesData>();

            _ableToChange = true;
        }

        public void CheckNextState(List<CellModel> neighbours)
        {
            int liveNeighbours = 0;

            foreach (CellModel neighbour in neighbours)
            {
                if (neighbour.GetCurrentState() == CellStatesData.live)
                {
                    liveNeighbours++;
                }
            }

            if (_currentState == CellStatesData.live)
            {
                if (liveNeighbours <= _boardConfigData.MinNeighboursToLife || liveNeighbours >= _boardConfigData.MaxNeighboursToLife)
                {
                    _nextState = CellStatesData.dead;
                }
            }
            else if (_currentState == CellStatesData.dead)
            {
                if (liveNeighbours == _boardConfigData.MinNeighboursToBorn)
                {
                    _nextState = CellStatesData.live;
                }
            }
            else
            {
                Debug.LogError(" state not valid: " + _currentState);
            }
        }

        public void SetAbleToChange(bool dragging)
		{
            _ableToChange = !dragging;
		}

        public void UpdateCurrentState()
        {
            if (_nextState == CellStatesData.unkown) return;

            _currentState = _nextState;
            _nextState = CellStatesData.unkown;
            UpdatedState.Value = _currentState;
        }

        public CellStatesData GetCurrentState()
        {
            return _currentState;
        }

        public void InverseCurrentState()
        {
            if (_ableToChange)
            {
                if (_currentState == CellStatesData.dead) _nextState = CellStatesData.live;
                else if (_currentState == CellStatesData.live) _nextState = CellStatesData.dead;
                else Debug.LogWarning(" has an invalid state: " + _currentState);

                UpdateCurrentState();
            }
			else
			{
                _ableToChange = true;
			}
        }

        public void Reset()
		{
            if (_currentState == CellStatesData.live) InverseCurrentState();
		}
    }
}

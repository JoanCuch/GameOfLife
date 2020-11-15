using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;
using UnityEngine.Events;
using UnityEngine.PlayerLoop;

namespace GOL.Board.Cell
{
    public class CellModel
    {
        private BoardConfigData _boardConfigData;

        private CellStatesData _currentState;
        private CellStatesData _nextState;

        private UnityEvent<CellStatesData> _updatedState;

        public CellModel(BoardConfigData _boardConfigData)
        {
            this._boardConfigData = _boardConfigData;
            _currentState = CellStatesData.dead;
            _nextState = CellStatesData.dead;

            _updatedState = new UnityEvent<CellStatesData>();
        }

        public BoardConfigData BoardConfigData => _boardConfigData;

        public void SubscribeToStateUpdates(UnityAction<CellStatesData> action) => _updatedState.AddListener(action);

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

        public void UpdateCurrentState()
        {
            if (_nextState == CellStatesData.unkown) return;

            _currentState = _nextState;
            _nextState = CellStatesData.unkown;
            _updatedState.Invoke(_currentState);
        }

        public CellStatesData GetCurrentState()
        {
            return _currentState;
        }

        public void InverseCurrentState()
        {
            if (_currentState == CellStatesData.dead) _nextState = CellStatesData.live;
            else if (_currentState == CellStatesData.live) _nextState = CellStatesData.dead;
            else Debug.LogWarning(" has an invalid state: " + _currentState);

            UpdateCurrentState();
        }
    }
}

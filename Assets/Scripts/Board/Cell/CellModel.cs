using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;
using GOL.Reactive;

namespace GOL.Board.Cell
{
    public class CellModel
    {
        private BoardConfigData _boardConfigData;
        private CellStatesData _nextState;
        public readonly ReactiveProperty<CellStatesData> CurrentState;
        private bool _ableToChange;

        public BoardConfigData BoardConfigData => _boardConfigData;

        public CellModel(BoardConfigData _boardConfigData)
        {
            this._boardConfigData = _boardConfigData;             
            _nextState = CellStatesData.dead;
            CurrentState = new ReactiveProperty<CellStatesData>();
            CurrentState.Value = CellStatesData.dead;

            _ableToChange = true;
        }

        public void CheckNextState(List<CellModel> neighbours)
        {
            int liveNeighbours = 0;

            foreach (CellModel neighbour in neighbours)
            {
                if (neighbour.CurrentState.Value == CellStatesData.live)
                {
                    liveNeighbours++;
                }
            }

            if (CurrentState.Value == CellStatesData.live)
            {
                if (liveNeighbours <= _boardConfigData.MinNeighboursToLife || liveNeighbours >= _boardConfigData.MaxNeighboursToLife)
                {
                    _nextState = CellStatesData.dead;
                }
            }
            else if (CurrentState.Value == CellStatesData.dead)
            {
                if (liveNeighbours == _boardConfigData.MinNeighboursToBorn)
                {
                    _nextState = CellStatesData.live;
                }
            }
            else
            {
                Debug.LogError(" state not valid: " + CurrentState);
            }
        }

        public void SetAbleToChange(bool dragging)
		{
            _ableToChange = !dragging;
		}

        public void UpdateCurrentState()
        {
            if (_nextState == CellStatesData.unkown) return;

            if (CurrentState.Value != _nextState) CurrentState.Value = _nextState;

            _nextState = CellStatesData.unkown;
        }

        public void InverseCurrentState()
        {
            if (_ableToChange)
            {
                if (CurrentState.Value == CellStatesData.dead) _nextState = CellStatesData.live;
                else if (CurrentState.Value == CellStatesData.live) _nextState = CellStatesData.dead;
                else Debug.LogWarning(" has an invalid state: " + CurrentState);

                UpdateCurrentState();
            }
			else
			{
                _ableToChange = true;
			}
        }

        public void Reset()
		{
            if (CurrentState.Value == CellStatesData.live) InverseCurrentState();
		}
    }
}

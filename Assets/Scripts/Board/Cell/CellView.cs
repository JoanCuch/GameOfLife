using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GOL.Configuration;
using UnityEngine.Events;

namespace GOL.Board.Cell
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        
        private BoardConfigData _boardConfigData;
        
        // Start is called before the first frame update
        public void Setup(BoardConfigData boardConfigData)
        {
            _boardConfigData = boardConfigData;
        }

        public void SubscribeToButton(UnityAction action) => _button.onClick.AddListener(action);

        public void UpdateCellColor(CellStatesData cellState)
        {
           if(cellState == CellStatesData.live)
           {
                _image.color = _boardConfigData.LiveColor;
           }
           else if (cellState == CellStatesData.dead)
           {
                _image.color = _boardConfigData.DeadColor;
           }
           else
           {
                Debug.LogError(name + "has an invalid state");
           }
        }
    }
}

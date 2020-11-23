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
        [SerializeField] private GridLayoutGroup _gridLayout;

        private BoardConfigData _boardConfigData;

        public void Setup(BoardConfigData _boardConfigData)
        {
            this._boardConfigData = _boardConfigData;
            _gridLayout.constraintCount = this._boardConfigData.BoardSize.x;           
        }

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

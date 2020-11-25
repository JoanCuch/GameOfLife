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
        private Vector3 _distanceOffset;
        private Vector3 _origin;
        private bool _validClick;

        private bool _sentEvent;
        private UnityEvent<bool> _draggingBoard;

        public void Setup(BoardConfigData _boardConfigData)
        {
            this._boardConfigData = _boardConfigData;
            _gridLayout.constraintCount = this._boardConfigData.BoardSize.x;
            _distanceOffset = Vector3.zero;
            _validClick = false;
            _sentEvent = false;
            _draggingBoard = new UnityEvent<bool>();
        }

        public void Update()
		{
            UpdateBoardMovement();
		}

        public void SubscribeToDraggingBoar(UnityAction<bool> action) => _draggingBoard.AddListener(action);

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

        public void UpdateBoardMovement()
		{
            
            if (Input.GetMouseButtonDown(_boardConfigData.MouseClickButton))
            {

                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = Camera.main.transform.position.z;

                RaycastHit2D buttonHit = Physics2D.Raycast(mousePosition, Vector3.forward);

                if (buttonHit && buttonHit.transform.gameObject.layer != _boardConfigData.ButtonsLayer)
                {
                    _validClick = true;                  
                    Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _distanceOffset = touchPos - transform.position;
                    _origin = transform.position;
                    _sentEvent = false;
                }
            }
            
            if (Input.GetMouseButtonUp(_boardConfigData.MouseClickButton))
			{
                _validClick = false;
                _origin = transform.position;
                _draggingBoard.Invoke(false);

            }

            if (_validClick && Input.GetMouseButton(_boardConfigData.MouseClickButton))
            {
                Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPosition = new Vector3(touchPos.x - _distanceOffset.x, touchPos.y - _distanceOffset.y, transform.position.z);
                transform.position = newPosition;

                if(!_sentEvent && Vector3.Distance(_origin, transform.position) >= _boardConfigData.MinDistanceToConsiderDragging)
				{
                    _draggingBoard.Invoke(true);
                    _sentEvent = true;
                }

            }
        }




    }
}

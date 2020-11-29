using UnityEngine;
using UnityEngine.UI;
using GOL.Configuration;
using GOL.Reactive;

namespace GOL.Board
{
    public class BoardView : MonoBehaviour
    {
        [SerializeField] private GridLayoutGroup _gridLayout;
        [SerializeField] private Camera _camera;
        private Vector3 _lastPosition;

        private BoardConfigData _boardConfigData;
        private Vector3 _origin;
        private bool _validClick;
        private ReactiveProperty<bool> _isDraggingBoard;

        public ReactiveProperty<bool> IsDraggingBoard => _isDraggingBoard;

        public void Setup(BoardConfigData boardConfigData)
        {
            _boardConfigData = boardConfigData;
            _gridLayout.constraintCount = _boardConfigData.BoardSize.x;
            _validClick = false;
            _isDraggingBoard = new ReactiveProperty<bool>(false);
            _lastPosition = Vector3.zero;
        }

        public void Update()
		{
            UpdateBoardMovement();
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
                    //_origin = new Vector3(Screen.width/2, Screen.height/2, _camera.transform.position.z);
                    _origin = Input.mousePosition;
                    _lastPosition = _origin;
                    /*Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    _distanceOffset = touchPos - _camera.transform.position;
                    _origin = _camera.transform.position;

                    Debug.Log("mouse down");
                    Debug.Log("touchPos: " + touchPos);
                    Debug.Log("distance offset: " + _distanceOffset);
                    Debug.Log("origin: " + _origin);*/                    
                }
            }
            
            if (Input.GetMouseButtonUp(_boardConfigData.MouseClickButton))
			{
                _validClick = false;
                _origin = _camera.transform.position;
                _isDraggingBoard.Value = false;
            }

            if (_validClick && Input.GetMouseButton(_boardConfigData.MouseClickButton))
            {
                Vector3 touchPos = Input.mousePosition;
                Vector3 offset = new Vector3(touchPos.x - _lastPosition.x, touchPos.y - _lastPosition.y, 0) / _boardConfigData.RatioPixelsUnits;
                    //Vector3 newPosition = new Vector3(touchPos.x - _distanceOffset.x, touchPos.y - _distanceOffset.y, 0) / _ratioPixelUnits;
                //newPosition.z = _camera.transform.position.z;            
                _camera.transform.position -= offset;
                _lastPosition = touchPos;

                /*Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 newPosition = new Vector3(touchPos.x + _distanceOffset.x, touchPos.y + _distanceOffset.y, _camera.transform.position.z);
                _camera.transform.position = newPosition;
                */

                if(!_isDraggingBoard.Value && Vector3.Distance(_origin, touchPos) >= _boardConfigData.MinDistanceToConsiderDragging)
				{
                    _isDraggingBoard.Value = true;
                }
            }
        }
    }
}

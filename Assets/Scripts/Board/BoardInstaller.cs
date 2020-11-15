using GOL.Board.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;


namespace GOL.Board
{
    public class BoardInstaller : MonoBehaviour
    {
        [SerializeField] private BoardView _view;
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Timer _timer;
        
        
        public void Install(BoardConfigData boardConfigData)
        {
            CellModel[,] cellModels = InstallCells(boardConfigData);

            BoardModel model = new BoardModel(boardConfigData, cellModels);

            new BoardController(model, _view, _timer);       
        }

        private CellModel[,] InstallCells(BoardConfigData boardConfigData)
        {
            CellModel[,] board = new CellModel[boardConfigData.BoardSize.x, boardConfigData.BoardSize.y];

            for (int y = 0; y < boardConfigData.BoardSize.y; y++)
            {
                for (int x = 0; x < boardConfigData.BoardSize.x; x++)
                {
                    GameObject newCell = Instantiate(_cellPrefab, _view.transform);
                    CellView cellView = newCell.GetComponent<CellView>();

                    CellModel cellModel = new CellModel(boardConfigData);
                    board[x, y] = cellModel;

                    new CellController(cellModel, cellView);                   
                }
            }

            return board;
        }
    }
}

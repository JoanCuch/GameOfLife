﻿using GOL.Board.Cell;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;
using GOL.GUI;
using GOL.Reactive;


namespace GOL.Board
{
    public class BoardInstaller : MonoBehaviour
    {
        [SerializeField] private BoardView _view;
        [SerializeField] private GUIView _guiView;
        [SerializeField] private GameObject _cellPrefab;
        [SerializeField] private Timer _timer;
             
        public void Install(BoardConfigData boardConfigData, GUIModel guiModel)
        {
            _timer.Setup(boardConfigData);
            _view.Setup(boardConfigData);

            List<CellModel> liveList = new List<CellModel>();
            CellModel[,] cellModels = InstallCells(boardConfigData, liveList);
            BoardModel model = new BoardModel(boardConfigData, cellModels, liveList);
            BoardController controller = new BoardController(model, _view, _timer, guiModel, _guiView);   
           
        }

        private CellModel[,] InstallCells(BoardConfigData boardConfigData, List<CellModel> liveList)
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

                    cellModel.CurrentState.Subscribe(new CellStateListCommand(cellModel, liveList).Execute);
                    _view.IsDraggingBoard.Subscribe(cellModel.SetAbleToChange);

                    new CellController(cellModel, cellView);                   
                }
            }

            return board;
        }
    }
}

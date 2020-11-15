using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GOL.Board.Cell
{

    public class CellController
    {
        public CellController(CellModel model, CellView view)
        {            
            view.Setup(model.BoardConfigData);

            view.SubscribeToButton(model.InverseCurrentState);
            model.SubscribeToStateUpdates(view.UpdateCellColor);

            model.UpdateCurrentState();
        }       
    }
}

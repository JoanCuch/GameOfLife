namespace GOL.Board.Cell
{
    public class CellController
    {
        public CellController(CellModel model, CellView view)
        {            
            view.Setup(model.BoardConfigData);
            view.SubscribeToButton(model.InverseCurrentState);

            model.CurrentState.Subscribe(view.UpdateCellColor);
            model.UpdateCurrentState();
        }       
    }
}

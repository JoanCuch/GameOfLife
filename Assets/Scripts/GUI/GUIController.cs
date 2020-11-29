namespace GOL.GUI
{
	public class GUIController
	{
		public GUIController(GUIView view, GUIModel model)
		{
			view.SubscribeToPlayButton(model.InversePlayPause);
			view.SubscribeToSizeScaleButton(scale => model.SizeScale.Value = scale);
			view.SubscribeToTimeScaleButton(scale => model.TimeScale.Value = scale);

			model.PlayText.Subscribe(view.SetPlayButtonText);
		}
	}
}

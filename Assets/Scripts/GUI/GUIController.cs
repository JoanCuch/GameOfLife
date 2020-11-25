using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace GOL.GUI
{
	public class GUIController
	{
		public GUIController(GUIView view, GUIModel model)
		{
			view.SubscribeToNextTurnButton(model.NextTurn);
			view.SubscribeToPlayButton(model.ChangePlayState);
			view.SubscribeToSizeScaleButton(model.ChangeSizeScale);
			view.SubscribeToTimeScaleButton(model.ChangeTimeScale);
			view.SubscribeToResetButton(model.Reset);

			model.SubscribeToPlayTextEvent(view.SetPlayButtonText);
		}
	}
}

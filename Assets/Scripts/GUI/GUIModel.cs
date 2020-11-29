using GOL.Configuration;
using GOL.Reactive;

namespace GOL.GUI {
    public class GUIModel
    {
        private GUIConfigData _GUIConfigData;

        public readonly ReactiveProperty<bool> Play;
        public readonly ReactiveProperty<string> PlayText;
        public readonly ReactiveProperty<float> TimeScale;
        public readonly ReactiveProperty<float> SizeScale;
        
        public GUIModel(GUIConfigData guiConfigData)
        {
            _GUIConfigData = guiConfigData;

            Play = new ReactiveProperty<bool>();
            PlayText = new ReactiveProperty<string>();
            TimeScale = new ReactiveProperty<float>();
            SizeScale = new ReactiveProperty<float>();
        }

        public void InversePlayPause()
		{
            Play.Value = !Play.Value;
            PlayText.Value = Play.Value ? _GUIConfigData.PauseButtonString : _GUIConfigData.PlayButtonString;
        }
    } 
}

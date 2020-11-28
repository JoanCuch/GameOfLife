using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using GOL.Configuration;
using GOL.Reactive;

namespace GOL.GUI {
    public class GUIModel
    {
        public readonly ReactiveProperty<bool> Play;
        public readonly ReactiveProperty<string> PlayText;
        public readonly ReactiveProperty<float> TimeScale;
        public readonly ReactiveProperty<float> SizeScale;

        private GUIConfigData _GUIConfigData;


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
		}

        public string GetTextOfPLayButton()
		{
			if (Play.Value)
			{
                return _GUIConfigData.PauseButtonString;
            }
			else
			{
                return _GUIConfigData.PlayButtonString;
			}            
		}


    } 
}

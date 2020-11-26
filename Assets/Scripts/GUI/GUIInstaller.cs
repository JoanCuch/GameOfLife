using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;


namespace GOL.GUI
{
    public class GUIInstaller : MonoBehaviour
    {
        [SerializeField] private GUIView _view;

        public void Install(GUIModel model)
		{
            new GUIController(_view, model); 
		}
    }
}


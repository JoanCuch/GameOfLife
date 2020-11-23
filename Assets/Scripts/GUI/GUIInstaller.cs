using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GOL.Configuration;


namespace GOL.GUI {

    public class GUIInstaller : MonoBehaviour
    {

        [SerializeField] private GUIView _view;
        private GUIModel _model;

        public void Install(GUIConfigData configData)
		{
            _model = new GUIModel(configData);

            new GUIController(_view, _model); 
		}

        public GUIModel GUIModel => _model;
    }

}


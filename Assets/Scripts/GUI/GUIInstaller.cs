using UnityEngine;
using GOL.Configuration;

namespace GOL.GUI
{
    public class GUIInstaller : MonoBehaviour
    {
        [SerializeField] private GUIView _view;

        public void Install(BoardConfigData boardConfigData, GUIModel model)
		{
            _view.Setup(boardConfigData);
            new GUIController(_view, model); 
		}
    }
}


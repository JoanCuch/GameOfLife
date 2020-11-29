using UnityEngine;

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


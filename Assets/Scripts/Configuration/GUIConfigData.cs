using UnityEngine;

namespace GOL.Configuration
{
    [CreateAssetMenu(menuName = "Config/GUIConfigData", fileName = "GUIConfigData")]
    public class GUIConfigData : ScriptableObject
    {
        [SerializeField] private string _playButtonString;
        [SerializeField] private string _pauseButtonString;
        public string PlayButtonString => _playButtonString;
        public string PauseButtonString => _pauseButtonString;
    }
}

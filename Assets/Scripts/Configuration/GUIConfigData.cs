using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GOL.Configuration
{
    [CreateAssetMenu(menuName = "Config/GUIConfigData", fileName = "GUIConfigData")]
    public class GUIConfigData : ScriptableObject
    {
        [SerializeField] private string playButtonString;
        [SerializeField] private string pauseButtonString;

        public string PlayButtonString => playButtonString;
        public string PauseButtonString => pauseButtonString;
    }
}

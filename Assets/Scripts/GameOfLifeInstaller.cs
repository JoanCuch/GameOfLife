using GOL.Board;
using GOL.GUI;
using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOL
{
    public class GameOfLifeInstaller : MonoBehaviour
    {
        [SerializeField] private BoardConfigData _boardConfigData;
        [SerializeField] private GUIConfigData _gUIConfigData;

        [SerializeField] private BoardInstaller _boardInstaller;
        [SerializeField] private GUIInstaller _gUIInstaller;


        // Start is called before the first frame update
        private void Start()
        {
            _gUIInstaller.Install(_gUIConfigData);
            _boardInstaller.Install(_boardConfigData, _gUIInstaller.GUIModel);
        }
    }
}

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
        [SerializeField] private GUIConfigData _guiConfigData;

        [SerializeField] private BoardInstaller _boardInstaller;
        [SerializeField] private GUIInstaller _guiInstaller;

        private void Start()
        {
            GUIModel guiModel = new GUIModel(_guiConfigData);

            _guiInstaller.Install(guiModel);
            _boardInstaller.Install(_boardConfigData, guiModel);
        }
    }
}

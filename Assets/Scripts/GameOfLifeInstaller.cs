using GOL.Board;
using GOL.Configuration;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOL
{
    public class GameOfLifeInstaller : MonoBehaviour
    {
        [SerializeField] private BoardConfigData _boardConfigData;

        [SerializeField] private BoardInstaller _boardInstaller;


        // Start is called before the first frame update
        private void Start()
        {
            _boardInstaller.Install(_boardConfigData);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Assertions;
public class GameManager : MonoBehaviour
{
    [SerializeField] private Board board;


    // Start is called before the first frame update
    void Start()
    {
        board.Initialize();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextTurn()
    {
        board.CheckCellState();
        board.UpdateCellState();
    }
}

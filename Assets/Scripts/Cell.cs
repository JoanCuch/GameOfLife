using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "Cell tile", menuName ="GameOfLife")]
public class Cell: Tile
{
    [SerializeField] private Color liveColor;
    [SerializeField] private Color deadColor;

    public enum CellStates { live, dead, unkown }
    private CellStates currentState;
    private CellStates nextState;

    private Vector3Int localPosition;

    public void Initialize(Vector3Int _localPosition)
    {
        localPosition = _localPosition;
        currentState = CellStates.dead;
        nextState = CellStates.unkown;
    }

  
    public void checkState(List<Cell> neighbours)
    {
        Debug.Log("local position: " + localPosition);
        
        if(localPosition.x % 2 == 0)
        {
            currentState = CellStates.live;
        }

        
        //Get cells around
        //Change next statee
    }

    public void updateState()
    {
        Debug.Log(currentState);
        if(currentState == CellStates.live)
        {
            color = liveColor;
        }
        else
        {
            color = deadColor;
        }


        currentState = nextState;
        nextState = CellStates.unkown;

        //Change tiles

    }

    public CellStates GetCurrentState()
    {
        return currentState;
    }
    public Vector3Int GetLocalPosition() { return localPosition; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Cell: MonoBehaviour
{
    [SerializeField] private Color liveColor;
    [SerializeField] private Color deadColor;
    [SerializeField] private Image image;

    public enum CellStates { live, dead, unkown }
    private CellStates currentState;
    private CellStates nextState;

    [SerializeField]private Vector2Int localPosition;

    public void Initialize(Vector2Int _localPosition)
    {
        localPosition = _localPosition;
        currentState = CellStates.dead;
        nextState = CellStates.unkown;

    }

  
    public void checkState(List<Cell> neighbours)
    {
        if(localPosition.x % 2 == 0)
        {
            currentState = CellStates.live;
        }

        
        //Get cells around
        //Change next statee
    }

    public void updateState()
    {
        if(currentState == CellStates.live)
        {
            
            
            image.color = liveColor;
        }
        else
        {
            image.color = deadColor;
        }

        currentState = nextState;
        nextState = CellStates.unkown;
    }

    public CellStates GetCurrentState()
    {
        return currentState;
    }
    public Vector2Int GetLocalPosition() { return localPosition; }
}

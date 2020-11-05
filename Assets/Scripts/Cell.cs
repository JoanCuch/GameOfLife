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
        nextState = CellStates.dead;
        UpdateCurrentState();

    }

  
    public void CheckNextState(List<Cell> neighbours)
    {
        if(localPosition.x % 2 == 0)
        {
            currentState = CellStates.live;
        }

        
        //Get cells around
        //Change next statee
    }

    public void UpdateCurrentState()
    {
        currentState = nextState;
        nextState = CellStates.unkown;

        if (currentState == CellStates.live)
        {        
            image.color = liveColor;
        }
        else
        {
            image.color = deadColor;
        }     
    }

    public CellStates GetCurrentState()
    {
        return currentState;
    }
    public Vector2Int GetLocalPosition() { return localPosition; }

    public void InverseCurrentState()
    {
        if (currentState == CellStates.dead) nextState = CellStates.live;
        else if (currentState == CellStates.live) nextState = CellStates.dead;
        else Debug.LogWarning(name + " has an invalid state: " + currentState);

        UpdateCurrentState();
    }
}

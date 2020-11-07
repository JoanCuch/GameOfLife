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

    [SerializeField] private int minNeighboursToLife;
    [SerializeField] private int maxNeighboursToLife;
    [SerializeField] private int minNeighbousToBorn;

    public enum CellStates { live, dead, unkown }
    private CellStates currentState;
    private CellStates nextState;

    [SerializeField]private Vector2Int localPosition;

    public void Initialize()
    {
        //localPosition = _localPosition;
        currentState = CellStates.dead;
        nextState = CellStates.dead;
        UpdateCurrentState();

    }

  
    public void CheckNextState(List<Cell> neighbours)
    {       
        int liveNeighbours = 0;

        foreach (Cell neighbour in neighbours)
        {
            if(neighbour.GetCurrentState() == CellStates.live)
            {
                liveNeighbours++;
            }
        }

        if(currentState == CellStates.live)
        {
            if(liveNeighbours <= minNeighboursToLife || liveNeighbours >= maxNeighboursToLife)
            {
                nextState = CellStates.dead;
            }
        }
        else if(currentState == CellStates.dead)
        {
            if(liveNeighbours == minNeighbousToBorn)
            {
                nextState = CellStates.live;
            }
        }
        else
        {
            Debug.LogError(name + " state not valid: " + currentState);
        }

        if(liveNeighbours >0)
            Debug.Log(name + " " + liveNeighbours + " " + nextState);
    }

    public void UpdateCurrentState()
    {
        if (nextState == CellStates.unkown) return;

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

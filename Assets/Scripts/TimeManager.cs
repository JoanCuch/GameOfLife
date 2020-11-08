using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float minDelay;
    [SerializeField] private float maxDelay;
    [SerializeField] private Scrollbar delayScrollBar;
    [SerializeField] private float delayMultiplier;
    private float standardDelay;

    [SerializeField] private string playString;
    [SerializeField] private string pauseString;
    [SerializeField] private Text text;

    private bool automatic;

    private float currentDelay;

    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        automatic = false;
        currentDelay = 0;
        ChangeDelay();
    }

    // Update is called once per frame
    void Update()
    {
        if (automatic)
        {
            currentDelay += Time.deltaTime;

            if(currentDelay >= standardDelay)
            {
                currentDelay = 0;
                NextTurn();
            }
        }
    }

    public void NextTurn()
    {
        gameManager.NextTurn();
    }

    public void AutomaticTurn()
    {
        automatic = !automatic;
        currentDelay = 0;

        if (automatic)
        {
            text.text = pauseString;
            Debug.Log("change");
        }
        else
        {
            Debug.Log("change no");
            text.text = playString;
        }
    }

    public void ChangeDelay()
    {
        standardDelay = Mathf.Lerp(minDelay, maxDelay, delayScrollBar.value) * delayMultiplier;
    }



}

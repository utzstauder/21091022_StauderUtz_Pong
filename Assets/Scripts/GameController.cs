using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Goal goalPlayerOne;
    public Goal goalPlayerTwo;

    public int scoreToWin = 3;

    private void Awake()
    {
        if (goalPlayerOne == null
            || goalPlayerTwo == null)
        {
            Debug.LogError("Please assign all Goal references.");
            enabled = false;
        }
    }

    private void Update()
    {
        if (goalPlayerOne.Score >= scoreToWin)
        {
            // P1 won
            Debug.Log("P1 won!");
        } else if (goalPlayerTwo.Score >= scoreToWin)
        {
            // P2 won
            Debug.Log("P2 won!");
        }
    }
}

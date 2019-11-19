using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Goal goalPlayerOne;
    public Goal goalPlayerTwo;

    public int scoreToWin = 3;

    bool playing = false;
    public bool IsPlaying { get { return playing; } }

    public delegate void gameStateChangeDelegate(bool playing, int winningPlayerId);
    public event gameStateChangeDelegate OnGameStateChanged;


    private void Awake()
    {
        if (goalPlayerOne == null || goalPlayerTwo == null)
        {
            Debug.LogError("Please assign all Goal references.");
            enabled = false;
        } else
        {
            goalPlayerOne.OnScoreChanged += GoalPlayerOne_OnScoreChanged;
            goalPlayerTwo.OnScoreChanged += GoalPlayerTwo_OnScoreChanged;
        }
    }

    private void GoalPlayerOne_OnScoreChanged(int newScore)
    {
        if (newScore >= scoreToWin)
        {
            playing = false;
            OnGameStateChanged?.Invoke(playing, 1);
        }
    }

    private void GoalPlayerTwo_OnScoreChanged(int newScore)
    {
        if (newScore >= scoreToWin)
        {
            playing = false;
            OnGameStateChanged?.Invoke(playing, 2);
        }
    }

    private void Start()
    {
        OnGameStateChanged?.Invoke(playing, 0);
    }

    private void Update()
    {
        if (!playing)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playing = true;
                OnGameStateChanged?.Invoke(playing, 0);
            }
        }
    }
}

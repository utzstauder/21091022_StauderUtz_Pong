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

    public delegate void gameStateChangeDelegate(bool playing);
    public event gameStateChangeDelegate OnGameStateChanged;


    private void Awake()
    {
        if (goalPlayerOne == null
            || goalPlayerTwo == null)
        {
            Debug.LogError("Please assign all Goal references.");
            enabled = false;
        }
    }

    private void Start()
    {
        OnGameStateChanged?.Invoke(playing);
    }

    private void Update()
    {
        if (playing)
        {
            if (goalPlayerOne.Score >= scoreToWin
            ||  goalPlayerTwo.Score >= scoreToWin)
            {
                playing = false;
                OnGameStateChanged?.Invoke(playing);
            }
        } else 
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                playing = true;
                OnGameStateChanged?.Invoke(playing);
            }
        }
    }
}

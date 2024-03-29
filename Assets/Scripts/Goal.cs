﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    int score = 0;

    public int Score
    {
        get
        {
            return score;
        }
    }

    public event System.Action<int> OnScoreChanged;

    GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.OnGameStateChanged += GameController_OnGameStateChanged;
        }
    }

    private void GameController_OnGameStateChanged(bool playing, int winningPlayerId)
    {
        if (playing)
        {
            ResetScore();
        }
    }

    void ResetScore()
    {
        score = 0;
        OnScoreChanged?.Invoke(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        OnScoreChanged?.Invoke(score);
        Debug.Log(gameObject.name + ": " + score);
    }
}

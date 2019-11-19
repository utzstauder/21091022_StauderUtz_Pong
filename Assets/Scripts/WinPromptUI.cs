using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPromptUI : MonoBehaviour
{
    Text textComponent;
    GameController gameController;

    private void Awake()
    {
        textComponent = GetComponent<Text>();

        gameController = GameObject.FindObjectOfType<GameController>();
        if (gameController != null)
        {
            gameController.OnGameStateChanged += GameController_OnGameStateChanged;
        }

        HidePrompt();
    }

    private void GameController_OnGameStateChanged(bool playing, int winningPlayerId)
    {
        if (playing)
        {
            HidePrompt();
        }else
        {
            if (winningPlayerId > 0)
            {
                ShowPrompt(winningPlayerId);
            }
        }
    }

    void ShowPrompt(int playerId)
    {
        textComponent.text = "Player " + playerId + " wins!";
        textComponent.enabled = true;
    }

    void HidePrompt()
    {
        textComponent.enabled = false;
    }
}

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        OnScoreChanged?.Invoke(score);
        Debug.Log(gameObject.name + ": " + score);
    }
}

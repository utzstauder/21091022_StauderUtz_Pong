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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score++;
        Debug.Log(gameObject.name + ": " + score);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    Text textRef;

    public Goal goalRef;

    private void Awake()
    {
        textRef = GetComponent<Text>();
        if (textRef == null)
        {
            Debug.LogError("Please attach a Text component.");
            enabled = false;
        }
        if (goalRef == null)
        {
            Debug.LogError("Please assign a Goal reference.");
            enabled = false;
        } else
        {
            goalRef.OnScoreChanged += GoalRef_OnScoreChanged;
        }
    }

    private void GoalRef_OnScoreChanged(int newScore)
    {
        textRef.text = "" + newScore;
    }

    private void Start()
    {
        textRef.text = "0";
    }
}

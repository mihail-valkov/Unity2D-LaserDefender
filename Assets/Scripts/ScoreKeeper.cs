using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int _score = 0;
    ScoreDisplay scoreDisplay;

    void Awake()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public int Score 
    {
        get { return _score; }
        set
        { 
            _score = value;
            scoreDisplay.UpdateScoreText(Score);
        }
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public void AddScore(int score)
    {
        Score += score;
    }
}

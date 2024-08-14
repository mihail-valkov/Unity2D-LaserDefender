using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    //slider for the health

    [SerializeField] Slider healthSlider;
    [SerializeField] TMPro.TextMeshProUGUI scoreText;
    [SerializeField] int initialLifeValue = 50;
    [SerializeField] int maxLifeValue = 50;


    void Start()
    {
        ResetScoreDisplay();
    }

    public void ResetScoreDisplay()
    {
        UpdateScoreText(GameManager.Instance.ScoreKeeper.Score);
        UpdateHealthText(initialLifeValue);
    }

    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateHealthText(int life)
    {
        //display life in % of maxLifeValue on the health slider
        healthSlider.value = (float)life / (float)maxLifeValue;
    }
}

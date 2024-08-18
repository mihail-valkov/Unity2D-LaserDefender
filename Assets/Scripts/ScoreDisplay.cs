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
    [SerializeField] Health playerHealth;


    void Start()
    {
        ResetScoreDisplay();
    }

    public void ResetScoreDisplay()
    {
        UpdateScoreText(GameManager.Instance.ScoreKeeper.Score);
        UpdateHealthText(initialLifeValue);
    }

    private void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    private void UpdateHealthText(int life)
    {
        //display life in % of maxLifeValue on the health slider
        healthSlider.value = (float)life / (float)maxLifeValue;
    }

    void Update()
    {
        UpdateScoreText(GameManager.Instance.ScoreKeeper.Score);
        UpdateHealthText(playerHealth.HealthValue);
    }
}

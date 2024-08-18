using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //score textmeshpro
    [SerializeField] TMPro.TextMeshProUGUI scoreText;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GameManager.Instance.ScoreKeeper.Score.ToString();
    }

    //playagain button
    public void PlayAgain()
    {
        GameManager.Instance.LoadNewGame();
    }

    public void MainMenu()
    {
        GameManager.Instance.LoadMainMenu();
    }
}

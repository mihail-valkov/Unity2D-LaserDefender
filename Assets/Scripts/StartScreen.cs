using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    //button start press
    public void StartGame()
    {
        //load game scene
        GameManager.Instance.LoadNewGame();
    }

    //button quit press
    public void QuitGame()
    {
        //quit game
        Application.Quit();
        Debug.Log("Quit Game");
    }
}

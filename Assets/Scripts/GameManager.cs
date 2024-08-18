using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] float waitForGameOver = 1.5f;
    //Singleton
    public static GameManager Instance { get; private set; }

    ScoreDisplay scoreDisplay;

    ScoreKeeper scoreKeeper;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            scoreKeeper = GetComponent<ScoreKeeper>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void LoadGameOver()
    {
        //reload scene after 2 seconds
        StartCoroutine(DelayLoadGameOverScene());
    }

    private IEnumerator DelayLoadGameOverScene()
    {
        yield return new WaitForSeconds(waitForGameOver);
        SceneManager.LoadScene("9-GameOverScreen");
    }

    public void LoadNewGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("1-Level1");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("0-StartScreen");
    }

    public void PlayRandomClip(AudioClip[] crashSounds, float volume, Vector3? position = null)
    {
        AudioClip clip = crashSounds[UnityEngine.Random.Range(0, crashSounds.Length)];
        PlayClip(clip, volume, position);
    }

    public void PlayClip(AudioClip clip, float volume, Vector3? position)
    {
        if (!position.HasValue)
        {
            position = Camera.main.transform.position;
        }

        //always apply camera y, z position
        position = new Vector3(position.Value.x, Camera.main.transform.position.y, Camera.main.transform.position.z);

        AudioSource.PlayClipAtPoint(clip, position.Value, volume);
    }

    public ScoreKeeper ScoreKeeper
    {
        get
        { 
            return scoreKeeper;
        }
    }
}

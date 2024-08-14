using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //Singleton
    public static GameManager Instance { get; private set; }

    ScoreDisplay scoreDisplay;

    ScoreKeeper scoreKeeper;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GetComponents();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            GetComponents();
            Destroy(gameObject);
        }
    }

    private void GetComponents()
    {
        Instance.scoreKeeper = GetComponent<ScoreKeeper>();
        Instance.scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    public void GameOver()
    {
        //reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        //reset score
        scoreKeeper.ResetScore();
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] GameObject deathVFX;
    [SerializeField] ParticleSystem hitEffectPrefab;
    [SerializeField] ParticleSystem explodeEffectPrefab;
    [SerializeField] AudioClip[] crashSounds;
    [SerializeField] AudioClip hitClip;

    [Range(0, 1)][SerializeField] float explosionSoundVolume = 0.5f;

    ScoreDisplay scoreDisplay;

    CameraShake cameraShake;


    void Awake()
    {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
    }

    void Start()
    {
        if (CompareTag("Player"))
        {
            cameraShake = Camera.main.GetComponent<CameraShake>();
        }
    }

    public void DealDamage(int damage)
    {
        health -= damage;
        PlayHitEffect();

        if (health <= 0)
        {
            TriggerDeathVFX();
            KeepScore();
            Destroy(gameObject);
        }
    }

    private void KeepScore()
    {
        Enemy enemy = GetComponent<Enemy>();
        if (enemy)
        {
            GameManager.Instance.ScoreKeeper.AddScore(enemy.KillScore);
        }
    }

    private void PlayHitEffect()
    {
        if (hitEffectPrefab)
        {
            ParticleSystem hitEffect = Instantiate(hitEffectPrefab, transform);
            Destroy(hitEffect.gameObject, hitEffect.main.duration + hitEffect.main.startLifetime.constantMax);
        }
        if (hitClip)
        {
            GameManager.Instance.PlayClip(hitClip, explosionSoundVolume, transform.position);
        }
    }

    private void TriggerDeathVFX()
    {
        GameManager.Instance.PlayRandomClip(crashSounds, explosionSoundVolume, transform.position);
        ParticleSystem hitEffect = Instantiate(explodeEffectPrefab, transform.position, Quaternion.identity);
        Destroy(hitEffect.gameObject, hitEffect.main.duration + hitEffect.main.startLifetime.constantMax);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) 
            return;

        
        this.DealDamage(damageDealer.GetDamage());

        //Debug.Log("Hit by: " + damageDealer.name + "; Health: " + health);
        damageDealer.Hit();

        //if this is the player, do camera shake
        if (CompareTag("Player"))
        { 
            if (cameraShake) cameraShake.Shake();
            scoreDisplay.UpdateHealthText(health);
            if (health <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}

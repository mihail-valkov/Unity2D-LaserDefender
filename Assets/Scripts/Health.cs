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

    CameraShake cameraShake;

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
            Destroy(gameObject);
        }
    }

    private void PlayHitEffect()
    {
        if (hitEffectPrefab)
        {
            ParticleSystem hitEffect = Instantiate(hitEffectPrefab, transform);
            Destroy(hitEffect.gameObject, hitEffect.main.duration + hitEffect.main.startLifetime.constantMax);
        }
    }

    private void TriggerDeathVFX()
    {
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
            if (health <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}

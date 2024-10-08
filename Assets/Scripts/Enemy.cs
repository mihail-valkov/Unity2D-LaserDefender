using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float minShootInterval = 0.2f;
    [SerializeField] float maxShootInterval = 1f;
    float nextShootTime;
    private LaserShooter laserShooter;

    [SerializeField] int killScore = 10;
    public int KillScore { get { return killScore; } }

    void Awake()
    {
        //move also the Background object in paralax effect
        laserShooter = GetComponent<LaserShooter>();
    }

    void Start()
    {
        CalculateNextShootTime();
    }

    private void CalculateNextShootTime()
    {
        nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
    }

    void Update()
    {
        //instantiate laser on random between minShootInterval and maxShootInterval
            
        if (Time.time > nextShootTime)
        {
            laserShooter.Fire();
            nextShootTime = Time.time + Random.Range(minShootInterval, maxShootInterval);
        }
    }

}

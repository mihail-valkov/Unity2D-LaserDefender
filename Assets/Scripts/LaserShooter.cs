using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] bool isEnemyLaser = false;


    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);
        laser.GetComponent<LaserProjectile>().IsEnemyLaser = isEnemyLaser;
    }
}

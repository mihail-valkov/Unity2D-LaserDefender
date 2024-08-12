using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserShooter : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] bool isEnemyLaser = false;
    [SerializeField] AudioClip[] laserSounds;
    [Range(0, 1)][SerializeField] float fireSoundVolume = 0.5f;

    public void Fire()
    {
        GameObject laser = Instantiate(laserPrefab, transform.position, transform.rotation);
        laser.GetComponent<LaserProjectile>().IsEnemyLaser = isEnemyLaser;

        GameManager.Instance.PlayRandomClip(laserSounds, fireSoundVolume, transform.position);
    }
}

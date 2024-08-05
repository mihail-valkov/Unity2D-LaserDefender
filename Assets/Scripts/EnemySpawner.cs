using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float minSpawnDelay = 0.2f;
    [SerializeField] float maxSpawnDelay = 2f;

    private bool isLooping = true;

    WaveConfigSO currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    public WaveConfigSO GetWaveConfig()
    {
        return currentWave;
    }

    private void SpawnEnemies()
    {
        StartCoroutine(SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        do
        {
        //loop through all the waveConfigs, wait untill previous wave have finished spawning all enemies
            foreach (WaveConfigSO waveConfig in waveConfigs)
            {
                currentWave = waveConfig;

                yield return new WaitForSeconds(currentWave.GetInitialDelay());
                            
                for (int i = 0; i < currentWave.GetEnnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartWaypoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                }
            }
        }
        while (isLooping);
    }
}

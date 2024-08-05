using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] float initialDelay = 0.5f;
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetInitialDelay()
    {
        return initialDelay;
    }

    public Transform GetStartWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform child in pathPrefab)
        {
            waveWaypoints.Add(child);
        }

        return waveWaypoints;
    }

    public int GetEnnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }
}

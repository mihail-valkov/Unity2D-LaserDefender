using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int currentWaypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
    }

    void Update()
    {
        //follow the waypoints
        FollowWaypoints();
    }

    private void FollowWaypoints()
    {
        if (currentWaypointIndex >= waypoints.Count)
        {
            Destroy(gameObject);
            return;
        }
        var waypoint = waypoints[currentWaypointIndex];

        transform.position = Vector2.MoveTowards(transform.position, waypoint.position, waveConfig.GetMoveSpeed() * Time.deltaTime);
        //if position is close within a small value to the waypoint position, move to the next waypoint
        if (Vector2.Distance(transform.position, waypoint.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }
}

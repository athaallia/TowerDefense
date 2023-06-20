using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int waypointIndex = 0;

    private Enemy enemy;



    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypointTransform[0];
    }



    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }



    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.waypointTransform.Length - 1)
        {
            EndPath();
            return;
        }

        waypointIndex++;
        target = Waypoints.waypointTransform[waypointIndex];
    }



    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}

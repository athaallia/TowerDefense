using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float speed = 10f;
    public int health = 100;
    public int moneyGain = 50;

    private Transform target;
    private int waypointIndex = 0;
    



    private void Start()
    {
        target = Waypoints.waypointTransform[0];
    }



    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
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



    public void TakeDamage(int amount)
    {
        Debug.Log($"ENEMY TAKE DAMAGE {amount}");

        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        Debug.Log("ENEMY DIE");

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.money += moneyGain;
        Destroy(gameObject);
    }



    private void EndPath()
    {
        PlayerStats.lives--;
        Destroy(gameObject);
    }
}

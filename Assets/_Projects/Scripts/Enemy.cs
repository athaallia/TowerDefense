using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    public float health = 100;
    public int moneyGain = 50;



    private void Start()
    {
        speed = startSpeed;
    }



    public void TakeDamage(float amount)
    {
        Debug.Log($"ENEMY TAKE DAMAGE {amount}");

        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }



    public void Slow(float percent)
    {
        speed = startSpeed * (1f - percent);
    }



    private void Die()
    {
        Debug.Log("ENEMY DIE");

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        PlayerStats.money += moneyGain;
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;
    public float startHealth = 100;
    private float health;

    public int moneyGain = 50;


    [Header("Unity Stuff")]
    public Image healthBar;


    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
    }



    public void TakeDamage(float amount)
    {
        Debug.Log($"ENEMY TAKE DAMAGE {amount}");

        startHealth -= amount;
        // healthBar.fillAmount = health / startHealth;
        healthBar.fillAmount = startHealth / 100;

        if (startHealth <= 0)
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

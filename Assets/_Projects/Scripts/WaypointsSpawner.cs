using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaypointsSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    public Wave[] waves;

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenItem = 4f;
    private float countdown = 2f;
    public TextMeshProUGUI spawnCountdownText;

    private int waypointIndex = 0;



    private void Update()
    {
        if (enemiesAlive > 0)
            return;

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnItem());
            countdown = timeBetweenItem;
            return;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        spawnCountdownText.text = string.Format("{0:00.00}", countdown);
    }



    IEnumerator SpawnItem()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waypointIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        
        waypointIndex++;

        if (waypointIndex == waves.Length)
        {
            Debug.Log("LEVEL WON!");
            this.enabled = false;
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        enemiesAlive++;
    }
}

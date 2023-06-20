using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaypointsSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenItem = 4f;
    private float countdown = 2f;
    public TextMeshProUGUI spawnCountdownText;

    private int waypointIndex = 0;



    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnItem());
            countdown = timeBetweenItem;
        }
        
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        spawnCountdownText.text = string.Format("{0:00.00}", countdown);
    }



    IEnumerator SpawnItem()
    {
        waypointIndex++;
        PlayerStats.rounds++;

        for (int i = 0; i < waypointIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

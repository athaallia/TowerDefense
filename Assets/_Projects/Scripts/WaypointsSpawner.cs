using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaypointsSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenItem = 5f;
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
        spawnCountdownText.text = Mathf.Floor(countdown).ToString();
    }



    IEnumerator SpawnItem()
    {
        waypointIndex++;

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

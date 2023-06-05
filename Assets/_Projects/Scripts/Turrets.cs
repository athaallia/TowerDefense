using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
    private Transform target;
    public Transform partToRotate;

    public float range = 15f;
    public float turnSpeed = 10f;
    public string enemyTag = "Enemy";



    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }



    private void Update()
    {
        if (target == null)
            return;

        // target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }



    private void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemny = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemny < shortestDistance)
            {
                shortestDistance = distanceToEnemny;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        
        else target = null;
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

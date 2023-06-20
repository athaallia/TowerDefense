using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public int damage = 50;
    public float speed = 70f;
    public float explosionRadius = 10f;

    public GameObject bulletImpactEffect;



    public void Seek(Transform _target)
    {
        target = _target;
    }



    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }



    private void HitTarget()
    {
        GameObject effectInstantiate = (GameObject)Instantiate(bulletImpactEffect, transform.position, transform.rotation);
        Destroy(effectInstantiate, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
    }



    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }



    private void Damage(Transform _enemy)
    {
        // Debug.Log("ENEMY DAMAGE");

        Enemy enemy = _enemy.GetComponent<Enemy>();

        if (enemy != null)
        {
            // Debug.Log("ENEMY TAKE DAMAGE");
            enemy.TakeDamage(damage);
        }
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

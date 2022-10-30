using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int splashRadius;
    public GameObject impactEffect;

    private float damage;

    public void Awake()
    {
        if (gameObject.name == "Arrow(Clone)")
        {
            damage = GameObject.FindGameObjectWithTag("BallistaTower").GetComponent<Tower>().damage;
        }
        else if (gameObject.name == "FrostBullet(Clone)")
        {
            damage = GameObject.FindGameObjectWithTag("FrostTower").GetComponent<Tower>().damage;
        }
        else if (gameObject.name == "CannonBall(Clone)")
        {
            damage = GameObject.FindGameObjectWithTag("TinyTower").GetComponent<Tower>().damage;
        }
    }

    public void Seek (Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        // Aim at targets body, not the floor
        Vector3 dir = (target.position + new Vector3(0, target.localScale.y/2, 0)) - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        if (impactEffect)
        {
            GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(effectIns, 2f);
        }

        if (gameObject.name == "CannonBall(Clone)")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(GameObject enemy in enemies)
            {
                float distanceSqr = (target.transform.position - enemy.transform.position).sqrMagnitude;
                if (distanceSqr < Mathf.PI * Mathf.Pow(splashRadius, 2) )
                    enemy.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
        else if (gameObject.name == "FrostBullet(Clone)")
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                float distanceSqr = (target.transform.position - enemy.transform.position).sqrMagnitude;
                if (distanceSqr < Mathf.PI * Mathf.Pow(splashRadius, 2))
                {
                    enemy.GetComponent<Enemy>().FrostSlow();
                    enemy.GetComponent<Enemy>().TakeDamage(damage);
                }
            }
        }
        else
            target.GetComponent<Enemy>().TakeDamage(damage);

        Destroy(gameObject);

    }
}

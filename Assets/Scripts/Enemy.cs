using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    WaveSpawner waveSpawner;
    public float speed;
    public int enemyHealth;
    

    private int level;
    private Transform target;
    private int wavepointIndex = 0;
    

    void Start()
    {
        level = SceneManager.GetActiveScene().name == "Level 1" ? 1 : 2;
        if (level == 1)
        {
            if (Vector3.Distance(transform.position, Waypoints.waypoints[0].position) > 30f)
                waypointIndex = 10;
        }

        target = Waypoints.waypoints[waypointIndex];

        waveSpawner = WaveSpawner.instance;
        enemyHealth = waveSpawner.waves[waveSpawner.waveIndex].health;

    }


    void Update()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.Translate(dir.normalized * speed / 2 * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    private void GetNextWayPoint()
    {
        if (level == 1)
        {
            if (waypointIndex == Waypoints.waypoints.Length - 2)
            {
                Destroy(gameObject);
                return;
            }

            waypointIndex = waypointIndex == 10 ? 4 : waypointIndex + 1;
            target = Waypoints.waypoints[waypointIndex];
        }
        else
        {
            if (waypointIndex == 30)
            {
                Destroy(gameObject);
                return;
            }

            int rand = Random.Range(0, 2);
            if (rand == 1)
            {
                if (wavepointIndex == 0)
                    wavepointIndex = 31;
            }

            if (wavepointIndex == 54)
                wavepointIndex = 26;
            else
                waypointIndex++;

            target = Waypoints.waypoints[waypointIndex];
        }

    }

    public void TakeDamage(int damage)
    {

        
        
        enemyHealth -= damage;
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}

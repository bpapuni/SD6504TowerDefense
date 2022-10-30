using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public float speed;
    public int enemyHealth;
    

    private int level;
    private Transform target;
    private int wavepointIndex = 0;
<<<<<<< HEAD
    
=======
>>>>>>> parent of e1585b4 (Added Tower Range Indicators)

    void Start()
    {
        level = SceneManager.GetActiveScene().name == "Level 1" ? 1 : 2;
        if (level == 1)
        {
            if (Vector3.Distance(transform.position, Waypoints.waypoints[0].position) > 30f)
                wavepointIndex = 10;
        }

        target = Waypoints.waypoints[wavepointIndex];

<<<<<<< HEAD
        waveSpawner = WaveSpawner.instance;
        enemyHealth = waveSpawner.waves[waveSpawner.waveIndex].health;

=======
>>>>>>> parent of e1585b4 (Added Tower Range Indicators)
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
            if (wavepointIndex == Waypoints.waypoints.Length - 2)
            {
                Destroy(gameObject);
                return;
            }

            wavepointIndex = wavepointIndex == 10 ? 4 : wavepointIndex + 1;
            target = Waypoints.waypoints[wavepointIndex];
        }
        else
        {
            if (wavepointIndex == 30)
            {
                Destroy(gameObject);
                return;
            }

            int rand = Random.Range(0, 2);
<<<<<<< HEAD
            if (rand == 1)
            {
                if (wavepointIndex == 0)
                    wavepointIndex = 31;
            }

=======
            if (rand == 1) { 
                if (wavepointIndex == 0)
                    wavepointIndex = 31;
            }
            
>>>>>>> parent of e1585b4 (Added Tower Range Indicators)
            if (wavepointIndex == 54)
                wavepointIndex = 26;
            else
                wavepointIndex++;

            target = Waypoints.waypoints[wavepointIndex];
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
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

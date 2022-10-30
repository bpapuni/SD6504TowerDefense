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
<<<<<<< Updated upstream
    private int wavepointIndex = 0;
    
=======
    private int waypointIndex = 0;
    public int health;

    public HealthBar healthBar;
>>>>>>> Stashed changes

    void Start()
    {
        level = SceneManager.GetActiveScene().name == "Level 1" ? 1 : 2;
        if (level == 1)
        {
            if (Vector3.Distance(transform.position, Waypoints.waypoints[0].position) > 30f)
                wavepointIndex = 10;
        }

        target = Waypoints.waypoints[wavepointIndex];

        WaveSpawner waveSpawner = WaveSpawner.instance;
        enemyHealth = waveSpawner.waves[waveSpawner.waveIndex].health;

<<<<<<< Updated upstream
=======
        waveSpawner = WaveSpawner.instance;
        health = waveSpawner.waves[waveSpawner.waveIndex].health;
        healthBar.SetMaxHealth(health);
>>>>>>> Stashed changes
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
            if (rand == 1)
            {
                if (wavepointIndex == 0)
                    wavepointIndex = 31;
            }

            if (wavepointIndex == 54)
                wavepointIndex = 26;
            else
                wavepointIndex++;

            target = Waypoints.waypoints[wavepointIndex];
        }

    }

    public void TakeDamage(int damage)
    {
<<<<<<< Updated upstream

        
        
        enemyHealth -= damage;
        if(enemyHealth <= 0)
=======
        health -= damage;
        healthBar.SetHealth(health);
        
        if(health <= 0)
>>>>>>> Stashed changes
        {
            Destroy(gameObject);
        }
    }

}

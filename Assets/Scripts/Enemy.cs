using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    WaveSpawner waveSpawner;
    Status status;
    public float speed;
    public int goldReward;

    private int level;
    private Transform target;
    private int waypointIndex = 0;
    private float health;
    private bool beingSlowed = false;
    private Coroutine slowEnemy;
    private float ogSpeed;
    private Renderer[] rend;
    private Color[] startColor;
    public Color frostSlowColor;

    public HealthBar healthBar;

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
        status = Status.instance;
        health = waveSpawner.waves[waveSpawner.waveIndex].health;

        if (waveSpawner.waveIndex >= 7)
            speed = speed * 1.5f;
        ogSpeed = speed;

        // Gain 20% size for every 300 health above baseline
        float sizeMultiplier = 1 + (-1 + health / 300) * 0.2f;
        if (!(name.Contains("Lilith") || name.Contains("Stoon")))
            transform.localScale = transform.localScale * sizeMultiplier;

        rend = gameObject.GetComponentsInChildren<Renderer>();
        startColor = new Color[rend.Length];
        for (int i = 0; i < rend.Length; i++)
        {
            if (rend[i].material.HasProperty("_Color"))
            {
                startColor[i] = rend[i].material.color;
            }
        }

        healthBar.SetMaxHealth(health);
    }


    void Update()
    {
        if (beingSlowed && health > 0)
        {
            speed = ogSpeed * 0.5f;
            for (int i = 0; i < rend.Length; i++)
                rend[i].material.color = frostSlowColor;
        }

        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.Translate(dir.normalized * speed/2 * Time.deltaTime, Space.World);

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
                status.UpdateLives(1);
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
                status.UpdateLives(1);

                return;
            }

            int rand = Random.Range(0, 2);
            if (rand == 1) { 
                if (waypointIndex == 0)
                    waypointIndex = 31;
            }
            
            if (waypointIndex == 54)
                waypointIndex = 26;
            else
                waypointIndex++;

            target = Waypoints.waypoints[waypointIndex];
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        if(health <= 0)  
        {
            status.UpdateGold(goldReward);
            speed = 0.001f;
            gameObject.GetComponent<Animator>().SetTrigger("die");
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    public void FrostSlow()
    {
        beingSlowed = true;
        if (slowEnemy != null)
            StopCoroutine(slowEnemy);
        slowEnemy = StartCoroutine(RemoveSlow());
    }

    IEnumerator RemoveSlow()
    {
        yield return new WaitForSeconds(3);
        beingSlowed = false;
        speed = ogSpeed;
        for (int i = 0; i < rend.Length; i++)
            rend[i].material.color = startColor[i];
    }
}

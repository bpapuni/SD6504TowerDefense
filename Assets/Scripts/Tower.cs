using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{

    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Fields")]
    public Transform partToRotate;
    public float turnSpeed = 10f;
    public GameObject Bullet;
    public Transform firePoint;
    public Color hoverColor;

    private Renderer[] rend;
    private Color[] startColor;

    void Start()
    {
        rend = gameObject.GetComponentsInChildren<Renderer>();
        startColor = new Color[rend.Length];
        for (int i = 0; i < rend.Length; i++)
        {
            if (rend[i].material.HasProperty("_Color"))
                startColor[i] = rend[i].material.color;
        }
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void OnMouseEnter()
    {
        for (int i = 0; i < rend.Length; i++)
            rend[i].material.color = hoverColor;
    }

    void OnMouseExit()
    {
        for (int i = 0; i < rend.Length; i++)
            rend[i].material.color = startColor[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.GetChild(0).position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            StartCoroutine(Shoot());
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    IEnumerator Shoot()
    {
        // Wait required for ballista tower to aim, else arrow shoots out sideways
        yield return new WaitForSeconds(0.3f);
        GameObject bulletGO = (GameObject)Instantiate(Bullet, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
            target = null;
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.DrawWireSphere(transform.position, range);
    //}
}

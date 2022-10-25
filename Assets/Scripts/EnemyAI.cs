using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    Transform flagTransform;
    NavMeshAgent agent;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        flagTransform = GameObject.FindGameObjectWithTag("Flags").transform;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(flagTransform.position, transform.position);
        if (distance > 2)
        {
            agent.SetDestination(flagTransform.position);
            //SET ANIM FOR WALKING
        }
        else
        {
            agent.updatePosition = false;
            //SET ANIM FOR ATTACKING HERE
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
    }
}

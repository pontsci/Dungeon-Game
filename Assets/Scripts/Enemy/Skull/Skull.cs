using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skull : MonoBehaviour
{

    public Transform playerTransform;
    public float stoppingDistance = 5f;
    protected float spawnStoppingDistance = 0.2f;
    protected Vector3 spawnPosition;
    protected bool isAtSpawn = true;
    protected NavMeshAgent agent;
    protected PlayerDetector playerDetector;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;
        playerDetector = GetComponentInChildren<PlayerDetector>();
        spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (playerDetector.playerDetected) {
            agent.SetDestination(playerTransform.position);
            if(agent.remainingDistance <= stoppingDistance)
            {
                FaceTarget();
            }
        }
        else
        {
            if(agent.remainingDistance <= spawnStoppingDistance)
            {
                isAtSpawn = true;
            }
        }
    }

    protected void FaceTarget()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    //lose the player, invoked by playerDetector immediately when losing the player
    public virtual void LosePlayer()
    {
        agent.SetDestination(spawnPosition);
        agent.stoppingDistance = spawnStoppingDistance;
    }

    public virtual void DetectPlayer()
    {
        agent.SetDestination(playerTransform.position);
        agent.stoppingDistance = stoppingDistance;
        isAtSpawn = false;
    }

}

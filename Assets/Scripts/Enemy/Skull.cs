using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skull : MonoBehaviour
{

    public Transform playerTransform;
    protected NavMeshAgent agent;
    protected PlayerDetector playerDetector;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        playerDetector = GetComponentInChildren<PlayerDetector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetector.playerDetected) {
            agent.SetDestination(playerTransform.position);
        }
    }

    //lose the player, invoked by playerDetector immediately when losing the player
    public void LosePlayer()
    {
        agent.SetDestination(gameObject.transform.position);
    }

}

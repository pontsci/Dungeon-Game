using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skull : MonoBehaviour
{

    public Transform playerTransform; //player's position

    public float stoppingDistance = 5f; //the stopping distance

    protected float spawnStoppingDistance = 0.2f; //the stopping distance when returning to spawn
    protected Vector3 spawnPosition; //the spawn position

    protected bool isAtSpawn = true; //are we at the spawn?
    protected bool shooting = false; //whether we are shoting or not

    protected EnemyHealth healthScript;

    protected AudioSource audioSource;
    [SerializeField] protected AudioClip onPlayerDetectedSound;

    protected NavMeshAgent agent; //our agent component

    protected GameObject detectionSphere; //the detection sphere
    protected PlayerDetector playerDetector; //the player detector script

    protected GameObject fireDetectionSphere;
    protected PlayerDetector firingDetector; //the player detection for firing

    protected Transform fireballSpawnPoint; //the spawn point of the fireball projectile
    [SerializeField] protected GameObject fireballPrefab; //the prefab to use for the fireball projectile


    // Start is called before the first frame update
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stoppingDistance;

        healthScript = GetComponent<EnemyHealth>();
        audioSource = GetComponent<AudioSource>();

        detectionSphere = transform.Find("DetectionSphere").gameObject;
        playerDetector = detectionSphere.GetComponent<PlayerDetector>();

        fireDetectionSphere = transform.Find("FireSphere").gameObject;
        firingDetector = fireDetectionSphere.GetComponent<PlayerDetector>();

        spawnPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        fireballSpawnPoint = transform.Find("FireballSpawn").GetComponent<Transform>();
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

    //spawn a fireball
    protected void Shoot()
    {
        Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
    }

    //lose the player, invoked by playerDetector immediately when losing the player
    public virtual void LosePlayer()
    {
        agent.SetDestination(spawnPosition);
        agent.stoppingDistance = spawnStoppingDistance;
    }

    //when we detect a player, set destinations
    public virtual void DetectPlayer()
    {
        agent.SetDestination(playerTransform.position);
        agent.stoppingDistance = stoppingDistance;
        isAtSpawn = false;
    }

    //if we're in range, set shooting true
    public virtual void InRangeToShoot()
    {
        shooting = true;
        InvokeRepeating("Shoot", 0.2f, 1f);
    }

    //if we're out of shooting range, set shooting false
    public virtual void OutOfRangeToShoot()
    {
        shooting = false;
        CancelInvoke("Shoot");
    }

    //the enemy is dead, do dying stuff
    public virtual void Die()
    {
        Destroy(gameObject);
    }

}

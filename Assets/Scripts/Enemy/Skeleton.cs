using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Skeleton : MonoBehaviour
{
    public GameObject player;
    public float bufferDistance = 5;
    Transform playerTransform;
    [SerializeField] private float followSpeed = .5f;
    public LookAtPlayer vision;
    // Start is called before the first frame update
    void Start()
    {
        GetPlayerTransform();
    }

    // Update is called once per frame
    void Update()
    {
        if (vision.isInView)
            ChasePlayer();
    }

    public void GetPlayerTransform()
    {
        playerTransform = player.transform;
    }

    private void ChasePlayer()
    {
        //transform.LookAt(playerTransform);
        Quaternion targetRotation = Quaternion.LookRotation(playerTransform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
        transform.position += transform.forward * followSpeed * Time.deltaTime;
    }
}

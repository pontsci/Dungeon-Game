using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    #region SerializeFields
    [SerializeField]
    int maxDistance = 10;
    [SerializeField]
    int minDistance = 3;
    [SerializeField]
    bool playerSighted = false;
    [SerializeField]
    int moveSpeed = 3;
    #endregion

    public Transform player;
    public Animator anim; 


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerSighted)
            playerFound();
    }

    private void playerFound()
    {
        Vector3 lookAtPlayer = player.position;
        lookAtPlayer.y = transform.position.y;
        transform.LookAt(lookAtPlayer);

        if(Vector3.Distance(transform.position, player.position) >= minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            anim.SetInteger("condition", 1);
            // Attack should go here as skeleton is close enough.

            //if(Vector3.Distance(transform.position, player.position) <= maxDistance)
            //{
            //    attackScript();
            //}
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
            playerSighted = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            playerSighted = false;
            anim.SetInteger("condition", 0);
        }
    }
}

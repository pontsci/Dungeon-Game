﻿using System;
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
    public bool playerReached = false;

    private bool followLastknownPos = false;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerSighted)
        {
            playerFound();
        }
        //if (followLastknownPos)
        //    stillFollowing();
    }

    IEnumerator followBeforeBored()
    {
        print("Entered bored state");
        float counter = 0;
        float disctractedInSeconds = 5;

        while(counter < disctractedInSeconds)
        {
            counter += Time.deltaTime;
            stillFollowing();
        }


        followLastknownPos = false;
        yield return null;
    }

    private void stillFollowing()
    {
        Vector3 lookAtPlayer = player.position;
        lookAtPlayer.y = transform.position.y;
        transform.LookAt(lookAtPlayer);

        if (Math.Ceiling(Vector3.Distance(transform.position, player.position)) > minDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            anim.SetInteger("condition", 1);
        }
    }

    private void playerFound()
    {
        Vector3 lookAtPlayer = player.position;
        lookAtPlayer.y = transform.position.y;
        transform.LookAt(lookAtPlayer);

        if(Math.Ceiling(Vector3.Distance(transform.position, player.position)) > minDistance)
        {
            //print(Math.Ceiling(Vector3.Distance(transform.position, player.position)) + " == " + minDistance);
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            anim.SetInteger("condition", 1);
            playerReached = false;           
        }
        else if(Math.Ceiling(Vector3.Distance(transform.position, player.position)) == minDistance)
        {
            playerReached = true;
            if(playerReached)
                anim.SetInteger("condition", 2);
        }
        //if (Vector3.Distance(transform.position, player.position) <= maxDistance)
        //{
        //    anim.SetInteger("condition", 2);
        //}
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == player)
        {
            playerSighted = true;
            followLastknownPos = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            //StartCoroutine(followBeforeBored());
            playerSighted = false;
            playerReached = false;
            anim.SetInteger("condition", 0);
        }
    }
}

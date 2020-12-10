using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullAmbusher : Skull
{    // Update is called once per frame
    private Animator animatorController;

    protected override void Start()
    {
        base.Start();
        animatorController = GetComponent<Animator>();
    }
    void Update()
    {
        if (playerDetector.playerDetected) {
            agent.SetDestination(playerTransform.position);
            animatorController.SetBool("playerDetected", true);
            animatorController.SetBool("isAtSpawn", false);
        }
    }
}

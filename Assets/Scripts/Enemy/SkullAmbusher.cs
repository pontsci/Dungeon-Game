using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this class handles the animations for the skull ambusher enemy, most variables are already set by the parent class
public class SkullAmbusher : Skull
{    
    private Animator animatorController;

    protected override void Start()
    {
        base.Start();
        animatorController = GetComponentInChildren<Animator>();
    }
    protected override void Update()
    {
        base.Update();

        //if we're at the spawn, then we need to go into the spawn idle position
        if (isAtSpawn)
        {
            animatorController.SetBool("isAtSpawn", true);
        }
        
    }

    public override void LosePlayer()
    {
        base.LosePlayer();
        animatorController.SetBool("playerDetected", false);
    }

    public override void DetectPlayer()
    {
        base.DetectPlayer();
        animatorController.SetBool("playerDetected", true);
        animatorController.SetBool("isAtSpawn", false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : Interactable
{
    //activated when player is in range and presses F
    public override void Activate()
    {
        //do the pickup action
        PickupAction();
        Destroy(gameObject);
    }

    //a generic pickup action, overrite in child
    public virtual void PickupAction()
    {
        Debug.Log("Picking Up!");
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}

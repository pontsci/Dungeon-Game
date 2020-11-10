using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public override void Activate()
    {
        if (inInteractSphere)
        {
            PickupAction();
            Destroy(gameObject);
        }
    }

    private void PickupAction()
    {
        Debug.Log("Picking Up!");
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
}

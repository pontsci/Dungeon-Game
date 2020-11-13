using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : Interactable
{
    public override void Activate(InputAction.CallbackContext context)
    {
        if (inInteractSphere && context.performed)
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

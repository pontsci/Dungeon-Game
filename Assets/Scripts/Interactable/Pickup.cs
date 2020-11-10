using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{


    public override void Activate()
    {
        PickupAction();
        Destroy(gameObject);
    }

    private void PickupAction()
    {
        throw new NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

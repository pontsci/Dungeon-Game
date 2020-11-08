using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //whether we're in the sphere or not
    protected bool inInteractSphere = false;

    private void OnTriggerEnter(Collider other)
    {
        //entering the sphere, we set to true that we are in
        if (other.tag == "InteractSphere")
        {
            Debug.Log("In Range!");
            inInteractSphere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //exiting the sphere, we set to false that we are in
        if (other.tag == "InteractSphere")
        {
            Debug.Log("Out of Range!");
            inInteractSphere = false;
        }
    }

    //a method invoked by the unity input manager on "F" key
    public abstract void Activate();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Interactable : MonoBehaviour
{
    //whether we're in the sphere or not
    protected bool inInteractSphere = false;

    public Material interactiveMaterial;
    public Material defaultMaterial;

    protected Renderer rend;

    protected virtual void Start()
    {
        //the renderer
        rend = gameObject.GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //entering the sphere, we set to true that we are in
        if (other.tag == "Player")
        {
            //Debug.Log("In Range!");
            //change material
            ChangeToInteractiveMaterial();
            inInteractSphere = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //exiting the sphere, we set to false that we are in
        if (other.tag == "Player")
        {
            //Debug.Log("Out of Range!");
            //change material
            ChangeToDefaultMaterial();
            inInteractSphere = false;
        }
    }

    //change to the default material provided
    protected void ChangeToDefaultMaterial()
    {
        rend.material = defaultMaterial;
    }

    //change to the interactive material provided
    protected void ChangeToInteractiveMaterial()
    {
        rend.material = interactiveMaterial;
    }

    //a method invoked by the unity input manager on "F" key
    public abstract void Activate(InputAction.CallbackContext context);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{


    ChangeMaterialOnEnterInteract changeScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Interactable")
        {
            Debug.Log("Detected Interactable!");
            changeScript = other.gameObject.GetComponent<ChangeMaterialOnEnterInteract>();
            changeScript.ChangeToInteractiveMaterial();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            Debug.Log("Detected Leaving Interactable!");
            changeScript = other.gameObject.GetComponent<ChangeMaterialOnEnterInteract>();
            changeScript.ChangeToDefaultMaterial();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactable")
        {
            


        }
    }
}

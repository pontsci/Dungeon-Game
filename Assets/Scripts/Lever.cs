using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    private Door doorScript;
    private bool inInteractSphere = false;

    // Start is called before the first frame update
    void Start()
    {
        doorScript = door.GetComponent<Door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "InteractSphere")
        {
            Debug.Log("In Range!");
            inInteractSphere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "InteractSphere")
        {
            Debug.Log("Out of Range!");
            inInteractSphere = false;
        }
    }

    public void ActivateLever()
    {
        if (inInteractSphere)
        {
            if (!doorScript.doorMoving)
            {
                doorScript.doorMoving = true;
                if (doorScript.doorClosed)
                {
                    Debug.Log("Lever says: Open the door!");
                    doorScript.OpenDoor();
                }
                else
                {
                    Debug.Log("Lever says: Close the door!");
                    doorScript.CloseDoor();
                }
            }
        }
    }
}

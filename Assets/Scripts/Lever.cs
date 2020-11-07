using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    public Door doorScript;

    // Start is called before the first frame update
    void Start()
    {
        doorScript = door.GetComponent<Door>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractSphere")
        {
            if (!doorScript.doorMoving)
            {
                if (Input.GetAxis("Interact") == 1)
                {
                    doorScript.doorMoving = true;
                    if (doorScript.doorClosed)
                    {
                        Debug.Log("Open the door!");
                        doorScript.OpenDoor();
                    }
                    else
                    {
                        Debug.Log("Close the door!");
                        doorScript.CloseDoor();
                    }
                }
            }
        }
    }
}

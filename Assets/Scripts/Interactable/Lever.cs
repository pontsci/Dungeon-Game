using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    public GameObject door;
    private Door doorScript;

    // Start is called before the first frame update
    void Start()
    {
        doorScript = door.GetComponent<Door>();
    }

    public override void Activate()
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

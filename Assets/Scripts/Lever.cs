using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject door;
    private RectTransform doorTransform;
    private bool doorMoving = false;
    private bool doorClosed = true;

    // Start is called before the first frame update
    void Start()
    {
        doorTransform = door.GetComponent<RectTransform>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "InteractSphere")
        {
            if (!doorMoving)
            {
                if (Input.GetAxis("Interact") == 1)
                {
                    doorMoving = true;
                    if (doorClosed)
                    {
                        OpenDoor();
                    }
                    else
                    {
                        CloseDoor();
                    }
                }
            }
        }
    }

    void OpenDoor()
    {
        Debug.Log("Open the door!");
        doorClosed = false;
        doorMoving = false;
    }

    void CloseDoor()
    {
        Debug.Log("Close the door!");
        doorClosed = true;
        doorMoving = false;
    }
}

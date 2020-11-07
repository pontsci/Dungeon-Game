using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorMoving { get; set; } = false;
    public bool doorClosed { get; set; } = true;

    private RectTransform doorTransform;
    // Start is called before the first frame update
    void Start()
    {
        doorTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseDoor()
    {
        Debug.Log("Door says: Closing the door.");
        doorClosed = true;
        Invoke("PlayCloseDoorAnimation", 5f);
    }

    public void OpenDoor()
    {
        Debug.Log("Door says: Opening the door.");
        doorClosed = false;
        Invoke("PlayOpenDoorAnimation", 5f);
    }

    private void PlayOpenDoorAnimation()
    {



        doorMoving = false;
    }

    private void PlayClosingDoorAnimation()
    {



        doorMoving = false;
    }

    
}

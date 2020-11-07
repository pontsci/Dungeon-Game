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
        
        doorClosed = true;
        doorMoving = false;
    }

    public void OpenDoor()
    {
        doorClosed = false;
        doorMoving = false;
    }

    
}

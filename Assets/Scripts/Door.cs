using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool doorMoving { get; set; } = false;
    public bool doorClosed { get; set; } = true;

    Animator animator;

    private RectTransform doorTransform;
    // Start is called before the first frame update
    void Start()
    {
        doorTransform = gameObject.GetComponent<RectTransform>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseDoor()
    {
        Debug.Log("Door says: Closing the door.");
        doorClosed = true;
        animator.SetBool("isClosing", true);
        animator.SetBool("isOpening", false);
        Invoke("ChangeDoorMoving", 2f);
    }

    public void OpenDoor()
    {
        Debug.Log("Door says: Opening the door.");
        doorClosed = false;
        animator.SetBool("isClosing", false);
        animator.SetBool("isOpening", true);
        Invoke("ChangeDoorMoving", 2f);
    }

    private void ChangeDoorMoving()
    {
        doorMoving = !doorMoving;
    }
}

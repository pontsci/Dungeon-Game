using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : Interactable
{
    public GameObject door;
    private Door doorScript;
    private Animator leverController;


    // Start is called before the first frame update
    protected override void Start()
    {
        //do parent start
        base.Start();
        doorScript = door.GetComponent<Door>();
        leverController = GetComponent<Animator>();
    }

    public override void Activate()
    {
        //activate the lever!
        if (!doorScript.doorMoving)
        {
            doorScript.doorMoving = true;
            if (doorScript.doorClosed)
            {
                //Debug.Log("Lever says: Open the door!");
                doorScript.OpenDoor();
            }
            else
            {
                //Debug.Log("Lever says: Close the door!");
                doorScript.CloseDoor();
            }

            //toggle the lever pulled status
            leverController.SetBool("pulled", !leverController.GetBool("pulled"));
        }
    }
}

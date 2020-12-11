using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : Interactable
{
    public GameObject door;
    [SerializeField] AudioClip leverDown;
    [SerializeField] AudioClip leverUp;
    private Door doorScript;
    private Animator leverController;
    private AudioSource audioSource;



    // Start is called before the first frame update
    protected override void Start()
    {
        //do parent start
        base.Start();
        doorScript = door.GetComponent<Door>();
        leverController = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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

    public void PlayLeverDown()
    {
        audioSource.PlayOneShot(leverDown);
    }

    public void PlayLeverUp()
    {
        audioSource.PlayOneShot(leverUp);
    }
}

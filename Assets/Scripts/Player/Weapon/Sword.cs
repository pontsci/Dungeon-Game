using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sword : MonoBehaviour
{

    private Animator swordAnimator;

    public bool swinging = false;

    private void Start()
    {
        swordAnimator = gameObject.GetComponent<Animator>();
    }

    public void Swing(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //Debug.Log("Swing!");
            if (swordAnimator.GetBool("isSwinging") == false)
            {
                swordAnimator.SetBool("isSwinging", true);
                swinging = true;
                swordAnimator.Play("SwordSwing");
            }
            else
            {
                //Debug.Log("In middle of swing animation!!!");
            }
        }
        else
            swinging = false;
    }
}

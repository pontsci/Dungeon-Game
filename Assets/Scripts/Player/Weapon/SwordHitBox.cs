using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{

    //private GameObject [] skel;
    private Sword action;
    private void Start()
    {
        action = GameObject.FindGameObjectWithTag("PlayerSword").GetComponent<Sword>();
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        

       // print(action.swinging);
        if (other.tag == ("Skeleton") && action.swinging)
        {
            print("Entered attack");
            other.GetComponentInParent<Skeleton>().damage(80);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{

    //private GameObject [] skel;
    private Sword action;
    private void Start()
    {
        //skel = GameObject.FindGameObjectsWithTag("Skeleton"); // many skeletons
        //skel = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<Skeleton>();
        action = GameObject.FindGameObjectWithTag("PlayerSword").GetComponent<Sword>(); // only 1 sword
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

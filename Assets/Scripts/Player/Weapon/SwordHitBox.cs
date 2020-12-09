using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitBox : MonoBehaviour
{

    private Skeleton skel;
    private Sword action;
    private void Start()
    {
        skel = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<Skeleton>();
        action = GameObject.FindGameObjectWithTag("PlayerSword").GetComponent<Sword>();
    }
    private void OnTriggerEnter(Collider other)
    {
        print(action.swinging);
        if (other.tag == ("Skeleton") && action.swinging)
        {
            print(other.tag);
            skel.damage(80);
        }
    }
}

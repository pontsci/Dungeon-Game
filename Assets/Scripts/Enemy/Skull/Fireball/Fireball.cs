using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] Vector3 target; //the target we want to fly towards

    public void Start()
    {
        
    }


    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemy : MonoBehaviour
{
    public TrapObject playerSword;
    private Health enemyHealthScript;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("We collided with : " + other);
        if (other.tag == "Skeleton")
        {
            enemyHealthScript = other.gameObject.GetComponent<Health>();
            enemyHealthScript.RemoveHealth(playerSword.removeHealthValue);
            //Destroy(other.gameObject);
        }
    }
}

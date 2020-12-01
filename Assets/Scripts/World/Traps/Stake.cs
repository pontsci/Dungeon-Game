using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake : MonoBehaviour
{
    public TrapObject stakeData;
    private Health playerHealthScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("We collided with: " + other);
            playerHealthScript = other.gameObject.GetComponent<Health>();
            Debug.Log("Health before: " + playerHealthScript.getHealth());
            playerHealthScript.RemoveHealth(stakeData.removeHealthValue);
            Debug.Log("Health after: " + playerHealthScript.getHealth());
            Destroy(playerHealthScript.gameObject);
        }
    }

    private void Update()
    {

    }
}

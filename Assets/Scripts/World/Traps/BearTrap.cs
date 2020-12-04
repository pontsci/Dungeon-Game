using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearTrap : MonoBehaviour
{
    public TrapObject bearTrapData;
    private Health playerHealthScript;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("We collided with : " + other);
        if (other.tag == "Player")
        {
            Debug.Log("We collided with: " + other);
            playerHealthScript = other.gameObject.GetComponent<Health>();
            Debug.Log("Health before: " + playerHealthScript.getHealth());
            playerHealthScript.RemoveHealth(bearTrapData.removeHealthValue);
            Debug.Log("Health after: " + playerHealthScript.getHealth());
            Destroy(gameObject);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

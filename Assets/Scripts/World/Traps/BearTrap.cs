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
            playerHealthScript = other.gameObject.GetComponent<Health>();
            playerHealthScript.RemoveHealth(bearTrapData.removeHealthValue);
            Destroy(gameObject);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

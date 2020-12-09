using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public TrapObject enemySwordData;
    private LookAtPlayer vision;
    private Health playerHealthScript;
    private bool canHitPlayer;

    void Start()
    {
        vision = GameObject.FindGameObjectWithTag("Skeleton").GetComponent<LookAtPlayer>();
        canHitPlayer = vision.playerReached;
    }
    // Update is called once per frame
    void Update()
    {
        canHitPlayer = vision.playerReached;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("We collided with : " + other);
        

        if (other.tag == "Player")
        {
            playerHealthScript = other.gameObject.GetComponent<Health>();
            if (canHitPlayer)
            {
                Debug.Log("We collided with : " + other.gameObject.GetComponent<Health>());
                playerHealthScript.RemoveHealth(enemySwordData.removeHealthValue);
            }
            //Destroy(gameObject);
        }
    }

}

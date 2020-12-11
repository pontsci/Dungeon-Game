using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullHitBox : MonoBehaviour
{
    public GameObject skullEnemy;
    
    public float damageCooldown = .4f;
    private bool hitRecently = false;
    private EnemyHealth skullHealthScript;

    private void Start()
    {
        skullHealthScript = skullEnemy.GetComponent<EnemyHealth>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerSword"))
        {
            if (!hitRecently)
            {
                Debug.Log("Collided with: " + other);
                if (other.CompareTag("PlayerSword"))
                {
                    skullHealthScript.RemoveHealth(other.gameObject.GetComponent<Sword>().damage);
                    hitRecently = true;
                    Invoke("HitRecentlyToggle", damageCooldown);
                }
            }
        }
    }

    private void HitRecentlyToggle()
    {
        hitRecently = !hitRecently;
    }
}

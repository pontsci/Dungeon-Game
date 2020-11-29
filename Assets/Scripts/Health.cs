using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MAX_HEALTH = 100;
    private int health;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHealth(int health_value)
    {
        health = health + health_value;
        if (health > MAX_HEALTH) {
            health = MAX_HEALTH;
        }
    }

    public void RemoveHealth(int health_value) {
        health = health - health_value;
        if (health <= 0) {
            health = 0;
            isDead = true; //may not be needed
            //go back to menu?
            //Destroy(gameObject);
        }
    }

    public int getHealth() {
        return health;
    }
}

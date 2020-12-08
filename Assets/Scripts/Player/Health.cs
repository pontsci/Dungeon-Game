using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MAX_HEALTH = 100;
    private int health;
    private bool isDead = false;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        healthBar.SetMaxHealth(MAX_HEALTH);
    }

    public void AddHealth(int health_value)
    {
        health = health + health_value;
        if (health > MAX_HEALTH) {
            health = MAX_HEALTH;
        }
        healthBar.SetHealth(health);
    }

    public void RemoveHealth(int health_value) {
        if (health - health_value <= 0)
        {
            health = 0;
            isDead = true; //may not be needed
            //go back to menu?
            healthBar.SetHealth(health);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            health = health - health_value;
            healthBar.SetHealth(health);
        }
    }

    public int getHealth() {
        return health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Health : MonoBehaviour
{
    public int MAX_HEALTH = 100;
    private int health;
    private bool isDead = false;
    private DisplayInventory displayScript;
    private bool isPoisoned = false;
    float elapsed = 0f;
    public Color poisonedColor;
    public Color healthyColor;

    private HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = MAX_HEALTH;
        //The line below is to set the max health of the character. If we wanted the character to have 200 instead of 100, that's what this function would be for.
        //However, this code is throwing a null error for some reason so we'll just comment it out. The health can still be set in the health canvas, health bar area. 
        //There is a MAX HEALTH variable.
        //healthBar.SetMaxHealth(MAX_HEALTH);
        healthBar = GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthBar>();
        displayScript = GameObject.FindGameObjectWithTag("InventoryScreen").GetComponent<DisplayInventory>();
        Time.timeScale = 1;
    }

    void Update()
    {

        if (isPoisoned)
        {
            setIsPoisoned(true);
            elapsed += Time.deltaTime;
            if (elapsed >= 5f)
            {
                elapsed = elapsed % 5f;
                RemoveHealth(5);
            }
        }
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
            healthBar.SetHealth(health);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().enabled = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            displayScript.ResetSlots();
            Time.timeScale = 0;
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
        }
        else
        {
            health = health - Mathf.Abs(health_value);
            healthBar.SetHealth(health);
            //Debug.Log("Current Health:" + health);
        }
    }

    public int getHealth() {
        return health;
    }

    public void setIsPoisoned(bool isPoisoned) {
        this.isPoisoned = isPoisoned;
        if (isPoisoned) {
            //If poisoned, make the health bar green
            Image img = GameObject.FindGameObjectWithTag("HealthFill").GetComponent<Image>();
            img.color = poisonedColor;
        }
        else if (!isPoisoned) {
            //If not poinsed, make the health bar red
            Image img = GameObject.FindGameObjectWithTag("HealthFill").GetComponent<Image>();
            img.color = healthyColor;
        }
    }

    private void OnGUI()
    {
        if (isDead)
        {
            
        }
    }
}

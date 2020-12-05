using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int MAX_FOOD = 100;
    private int food;

    public FoodBar foodBar;
    public Health playerHealthScript;
    float elapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        food = MAX_FOOD;
        foodBar.SetMaxFood(MAX_FOOD);
        //decreases food every 5 seconds with a 1 second delay when the game starts.
        InvokeRepeating("DecreaseFood", 1f, 5f);
    }

    void Update()
    {
        if (food == 0) {
            elapsed += Time.deltaTime;
            if (elapsed >= 5f)
            {
                elapsed = elapsed % 5f;
                playerHealthScript.RemoveHealth(1);
            }
        }
    }

    private void DecreaseFood() {
        RemoveFood(1);
    }

    public void AddFood(int food_value)
    {
        food = food + food_value;
        if (food > MAX_FOOD)
        {
            food = MAX_FOOD;
        }
        foodBar.SetFood(food);
    }

    public void RemoveFood(int food_value)
    {
        if (food - food_value < 0)
        {
            food = 0;
            //REMOVE HEALTH OVERTIME: NOT IMPLEMENTED YET.
            //May need to be implemented in the update area.
        }
        else {
            food = food - food_value;
        }
        foodBar.SetFood(food);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int MAX_FOOD = 100;
    private int food;

    public FoodBar foodBar;


    // Start is called before the first frame update
    void Start()
    {
        food = MAX_FOOD;
        foodBar.SetMaxFood(MAX_FOOD);
        //decreases food every 5 seconds with a 1 second delay when the game starts.
        InvokeRepeating("DecreaseFood", 1f, 5f);
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
        food = food - food_value;
        if (food <= 0)
        {
            //REMOVE HEALTH OVERTIME: NOT IMPLEMENTED YET.
            //May need to be implemented in the update area.
        }
        foodBar.SetFood(food);
    }
}

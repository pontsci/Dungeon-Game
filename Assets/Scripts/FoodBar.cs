using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBar : MonoBehaviour
{
    public int MAX_FOOD = 100;
    private int food;

    // Start is called before the first frame update
    void Start()
    {
        food = MAX_FOOD;
    }

    // Update is called once per frame
    void Update()
    {
        //MAKE FOOD DECAY OVER TIME: NOT IMPLEMENTED YET
    }

    public void AddFood(int food_value)
    {
        food = food + food_value;
        if (food > MAX_FOOD)
        {
            food = MAX_FOOD;
        }
    }

    public void RemoveFood(int food_value)
    {
        food = food - food_value;
        if (food <= 0)
        {
            //REMOVE HEALTH OVERTIME: NOT IMPLEMENTED YET.
            //May need to be implemented in the update area.
        }
    }
}

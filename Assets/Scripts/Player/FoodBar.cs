using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxFood(int food)
    {
        slider.maxValue = food;
        slider.value = food;
    }

    public void SetFood(int food)
    {
        slider.value = food;
    }
}

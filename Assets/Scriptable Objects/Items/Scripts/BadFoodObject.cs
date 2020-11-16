using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bad Food Object", menuName = "Inventory System/Items/Bad Food")]
public class BadFoodObject : FoodObject
{
    //20% chance of getting poisoned when eating a bad food
    public float poisonChance = 0.20f;
    private void Awake()
    {
        type = ItemType.BadFood;
    }
}

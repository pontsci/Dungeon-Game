using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bad Food Object", menuName = "Inventory System/Items/Bad Food")]
public class BadFoodObject : FoodObject
{
    private void Awake()
    {
        type = ItemType.BadFood;
    }
}

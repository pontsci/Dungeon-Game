using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : Pickup
{

    public ItemObject item;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    public override void PickupAction()
    {
        //do the parent PickupAction
        base.PickupAction();
        //inventory.AddItemToInventory(gameObject.AddComponent<Item>());
    }
}

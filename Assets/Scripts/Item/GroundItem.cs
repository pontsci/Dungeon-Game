using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : Pickup
{
    private InventoryObject playerInventory;
    public ItemObject item;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        playerInventory = playerScript.inventory;
    }

    //the PickupAction is called when Activated by the player with the F key
    public override void PickupAction()
    {
        //add it to the player inventory
        playerInventory.AddItem(new Item(item), 1);

        //this item is going to be destroyed, so remove it from the in range of player list
        playerScript.RemoveInteractableFromInteractableGameObjectsInRange(gameObject);

        //destroy the object
        Destroy(gameObject);
    }
}

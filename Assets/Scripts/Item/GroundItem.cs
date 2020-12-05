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
        Debug.Log("Trying to pick up an item!! -> " + gameObject);
        //add it to the player inventory
        playerInventory.AddItem(new Item(item), 1);
        Debug.Log("Try to get rid of the item in our interactables list...");
        //this item is going to be destroyed, so remove it from the in range of player list
        playerScript.RemoveInteractableFromInteractableGameObjectsInRange(gameObject);
        Debug.Log("Interactables List size after removing on pickup: " + playerScript.interactableGameObjectsInRange.Count);
        //destroy the object
        Destroy(gameObject);
    }
}

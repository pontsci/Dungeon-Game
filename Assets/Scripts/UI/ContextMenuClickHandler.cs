using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenuClickHandler : ClickHandler, IPointerClickHandler
{
    //private InventoryObject playerInventoryData;
    private DisplayInventory displayScript; // the displayScript for getting the hoveredItem
    private InventorySlot currentSlot; //the slot we're hovering
    private Food playerFoodScript; //the food script for adding/substracting from food

    private void Start()
    {
        displayScript = transform.parent.parent.GetComponent<DisplayInventory>();
        //playerInventoryData = displayScript.inventory;
        playerFoodScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Food>();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //Debug.Log("Left click on context menu!");
            currentSlot = displayScript.mouseItem.hoverSlot;

            //because of how the item was set up initially, all items have extraneous data
            //if I have time, this will be reworked, but right now this is how it is
            //this check is here to make sure it is indeed a food item that we are consuming, and not a sword.
            if(currentSlot.item.restoreHungerValue > 0)
            {
                playerFoodScript.AddFood(currentSlot.item.restoreHungerValue);
                currentSlot.DecreaseAmount(1);
            }
            else if(currentSlot.item.poisonChance > 0)
            {
                //chance to poison the player
                playerFoodScript.AddFood(currentSlot.item.restoreHungerValue);
                currentSlot.DecreaseAmount(1);
            }
            
            DeleteContextMenu();
        }
    }

    public void DeleteContextMenu()
    {
        Destroy(gameObject);
    }
}

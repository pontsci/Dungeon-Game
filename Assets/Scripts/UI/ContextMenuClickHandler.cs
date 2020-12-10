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
    private Health playerHealthScript; //the health script for adding poison
    int poisonChance;

    private void Start()
    {
        displayScript = transform.parent.parent.GetComponent<DisplayInventory>();
        //playerInventoryData = displayScript.inventory;
        playerFoodScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Food>();
        playerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
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
             if(currentSlot.item.poisonChance > 0)
            {
                poisonChance = Random.Range(0, 100);
                Debug.Log("Random Poison Chance: " + poisonChance);
                Debug.Log("Item   Poison Chance: " + currentSlot.item.poisonChance * 100);

                //If the random poisonChance generated is less than or equal to the poison chance, the player is poisoned.
                //Example: 
                //  Random poison Chance generated between 1-100
                //
                //  Banana Poison Chance: 15%
                //  Random Poison Chance: 46 -> Not poisoned
                //  Random Poison Chance: 10 -> Poisoned
                if ((currentSlot.item.poisonChance * 100) >= poisonChance) {
                    playerHealthScript.setIsPoisoned(true);
                }
                playerFoodScript.AddFood(currentSlot.item.restoreHungerValue);
                currentSlot.DecreaseAmount(1);
            }
            else if (currentSlot.item.restoreHungerValue > 0)
            {
                playerFoodScript.AddFood(currentSlot.item.restoreHungerValue);
                currentSlot.DecreaseAmount(1);
            }
            else
            {
                playerHealthScript.setIsPoisoned(false);
                playerHealthScript.AddHealth(50);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContextMenuClickHandler : ClickHandler, IPointerClickHandler
{
    // Start is called before the first frame update
    private InventoryObject playerInventoryData;
    private DisplayInventory displayScript;
    private InventorySlot currentSlot;
    private Food playerFoodScript;

    private void Start()
    {
        displayScript = transform.parent.parent.GetComponent<DisplayInventory>();
        playerInventoryData = displayScript.inventory;
        playerFoodScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Food>();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click on context menu!");
            currentSlot = displayScript.mouseItem.hoverSlot;
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

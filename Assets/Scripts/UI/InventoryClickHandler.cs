using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryClickHandler : ClickHandler, IPointerClickHandler
{
    public GameObject contextMenuPrefab;
    private DisplayInventory displayScript;

    private void Start()
    {
        displayScript = transform.parent.GetComponent<DisplayInventory>();
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //Debug.Log("Right click on slot!");
            Dictionary<GameObject, InventorySlot> itemToSlotHash = displayScript.itemToSlotHash;
            GameObject mouseHoverObj = displayScript.mouseItem.hoverObj;
            
            if (itemToSlotHash.ContainsKey(mouseHoverObj))
            {
                if (itemToSlotHash[mouseHoverObj].amount >= 1)
                {

                    var obj = Instantiate(contextMenuPrefab, Input.mousePosition, Quaternion.identity, transform);
                    if (itemToSlotHash[mouseHoverObj].item.restoreHungerValue > 0)
                    {
                        Text text = obj.GetComponentInChildren<Text>();
                        text.text = "Eat";
                    }
                    else
                    {
                        Text text = obj.GetComponentInChildren<Text>();
                        text.text = "Undefined";
                    }
                }
            }
        }
    }
}

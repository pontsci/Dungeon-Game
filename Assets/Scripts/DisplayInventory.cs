﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem mouseItem = new MouseItem();
    public GameObject inventoryPrefab;
    public InventoryObject inventory;

    Dictionary<GameObject, InventorySlot> itemToSlotHash = new Dictionary<GameObject, InventorySlot>();
    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot> slot in itemToSlotHash)
        {
            if(slot.Value.ID >= 0)
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[slot.Value.ID].uiDisplay;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = slot.Value.amount == 1 ? "" : slot.Value.amount.ToString("n0");
            }
            else
            {
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                slot.Key.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void CreateSlots()
    {
        itemToSlotHash = new Dictionary<GameObject, InventorySlot>(); //this line may not be needed
        for (int i = 0; i < inventory.inventory.slots.Length; i++)
        {
            var obj = Instantiate(inventoryPrefab, Vector3.zero, Quaternion.identity, transform);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });

            itemToSlotHash.Add(obj, inventory.inventory.slots[i]);
        }

    }

    public void OnEnter(GameObject obj)
    {
        mouseItem.hoverObj = obj;
        if (itemToSlotHash.ContainsKey(obj))
        {
            mouseItem.hoverSlot = itemToSlotHash[obj];
        }
    }
    public void OnExit(GameObject obj)
    {
        mouseItem.hoverObj = null;
        mouseItem.hoverSlot = null;
        
    }
    public void OnDragStart(GameObject obj)
    {
        //creates a representation of the object we are dragging
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        rt.sizeDelta = new Vector2(75, 75);
        mouseObject.transform.SetParent(transform.parent);

        //if there is an object in the slot
        if (itemToSlotHash[obj].ID >= 0)
        {
            //set the representative image
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemToSlotHash[obj].ID].uiDisplay;

            //mouse's raytrace should ignore this image
            img.raycastTarget = false;
        }

        //keep a reference to this object we created, for dragging around the screen later, setting in a new slot, etc.
        mouseItem.obj = mouseObject;
        mouseItem.slot = itemToSlotHash[obj];
    }
    public void OnDragEnd(GameObject obj)
    {
        if (mouseItem.hoverObj)
        {
            inventory.SwapSlots(itemToSlotHash[obj], itemToSlotHash[mouseItem.hoverObj]);
        }
        else
        {
            inventory.RemoveItem(itemToSlotHash[obj].item);
        }
        Destroy(mouseItem.obj);
        mouseItem.slot = null;
    }
    public void OnDrag(GameObject obj)
    {
        if(mouseItem.obj != null)
        {
            mouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
        }
    }

    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
}

public class MouseItem
{
    public GameObject obj; //the attached to our mouse
    public InventorySlot slot; //the data of that attached item
    public InventorySlot hoverSlot; //the slot we're hovering
    public GameObject hoverObj; //the object in game we are hovering
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory inventory;

    public void AddItem(Item item, int amount)
    {
        //if an item has buffs, don't stack it
        if (item.buffs.Length > 0)
        {
            SetEmptySlot(item, amount);
            return;
        }

        //stack the item if we have it already
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].ID == item.ID)
            {
                inventory.slots[i].AddAmount(amount);
                return;
            }
        }
        SetEmptySlot(item, amount);
    }

    public InventorySlot SetEmptySlot(Item item, int amount)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.slots[i].ID <= -1)
            {
                inventory.slots[i].UpdateSlot(item.ID, item, amount);
                return inventory.slots[i];
            }
        }
        //setup functionality for full inventory
        return null;
    }

    //swaps two items by updating their slots
    public void SwapSlots(InventorySlot itemOne, InventorySlot itemTwo)
    {
        InventorySlot temp = new InventorySlot(itemTwo.ID, itemTwo.item, itemTwo.amount);
        itemTwo.UpdateSlot(itemOne.ID, itemOne.item, itemOne.amount);
        itemOne.UpdateSlot(temp.ID, temp.item, temp.amount);
    }

    public void RemoveItem(Item item)
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if(inventory.slots[i].item == item)
            {
                inventory.slots[i].UpdateSlot(-1, null, 0);
            }
        }
    }


    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, inventory);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Inventory newInventory = (Inventory)formatter.Deserialize(stream);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                inventory.slots[i].UpdateSlot(newInventory.slots[i].ID, newInventory.slots[i].item, newInventory.slots[i].amount);
            }
            stream.Close();

        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        inventory = new Inventory();
    }
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] slots = new InventorySlot[24];
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;

    public InventorySlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public InventorySlot(int ID, Item item, int amount)
    {
        this.ID = ID;
        this.item = item;
        this.amount = amount;
    }

    public void UpdateSlot(int ID, Item item, int amount)
    {
        this.ID = ID;
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void DecreaseAmount(int value)
    {
        amount -= Mathf.Abs(value);
        //if we hit zero, null the slot
        if(amount == 0)
        {
            UpdateSlot(-1, null, 0);
        }
    }
}

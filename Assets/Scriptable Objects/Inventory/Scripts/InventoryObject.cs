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
    public Inventory inventoryContainer;

    public void AddItem(Item item, int amount)
    {
        //if an item has buffs, don't stack it
        if (item.buffs.Length > 0)
        {
            SetEmptySlot(item, amount);
            return;
        }

        //stack the item if we have it already
        for (int i = 0; i < inventoryContainer.Items.Length; i++)
        {
            if (inventoryContainer.Items[i].ID == item.ID)
            {
                inventoryContainer.Items[i].AddAmount(amount);
                return;
            }
        }
        SetEmptySlot(item, amount);
    }

    public InventorySlot SetEmptySlot(Item item, int amount)
    {
        for (int i = 0; i < inventoryContainer.Items.Length; i++)
        {
            if (inventoryContainer.Items[i].ID <= -1)
            {
                inventoryContainer.Items[i].UpdateSlot(item.ID, item, amount);
                return inventoryContainer.Items[i];
            }
        }
        //setup functionality for full inventory
        return null;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, inventoryContainer);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            inventoryContainer = (Inventory)formatter.Deserialize(stream);
            stream.Close();

        }
    }
    [ContextMenu("Clear")]
    public void Clear()
    {
        inventoryContainer = new Inventory();
    }
}

[System.Serializable]
public class Inventory
{
    public InventorySlot[] Items = new InventorySlot[24];
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;

    public InventorySlot()
    {
        this.ID = -1;
        this.item = null;
        this.amount = 0;
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
}

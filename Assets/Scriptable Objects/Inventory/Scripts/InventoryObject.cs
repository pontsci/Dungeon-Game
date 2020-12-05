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
        if(item.buffs.Length > 0)
        {
            inventoryContainer.Items.Add(new InventorySlot(item.ID, item, amount));
            return;
        }

        //stack the item if we have it already
        for(int i = 0; i < inventoryContainer.Items.Count; i++)
        {
            if(inventoryContainer.Items[i].item.ID == item.ID)
            {
                inventoryContainer.Items[i].AddAmount(amount);
                return;
            }
        }
        inventoryContainer.Items.Add(new InventorySlot(item.ID, item, amount));
    }

    [ContextMenu("Save")]
    public void Save()
    {
        //string saveData = JsonUtility.ToJson(this, true);
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        //bf.Serialize(file, saveData);
        //file.Close();

        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, inventoryContainer);
        stream.Close();
    }

    [ContextMenu("Load")]
    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            //JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            //file.Close();
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
    public List<InventorySlot> Items = new List<InventorySlot>();
}

[System.Serializable]
public class InventorySlot
{
    public int ID;
    public Item item;
    public int amount;
    public InventorySlot(int ID, Item item, int amount)
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

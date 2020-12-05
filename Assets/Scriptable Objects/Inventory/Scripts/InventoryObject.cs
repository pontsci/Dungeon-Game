using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
{
    public string savePath;
    public ItemDatabaseObject database;
    public Inventory Container;

    public void AddItem(ItemObject item, int amount)
    {
        for(int i = 0; i < Container.Items.Count; i++)
        {
            if(Container.Items[i].item == item)
            {
                Container.Items[i].AddAmount(amount);
                return;
            }
        }
        Container.Items.Add(new InventorySlot(database.GetID[item], item, amount));
    }

    public void Save()
    {
        string saveData = JsonUtility.ToJson(this, true);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
        bf.Serialize(file, saveData);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath))){
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
            JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(), this);
            file.Close();
        }

    }

    public void OnAfterDeserialize()
    {
        for (int i = 0; i < Container.Items.Count; i++)
        {
            Debug.Log("The ID given: " + Container.Items[i].ID);
            Debug.Log("The item received: " + database.GetItem[Container.Items[i].ID]);
            Container.Items[i].item = database.GetItem[Container.Items[i].ID];
        }
    }

    public void OnBeforeSerialize()
    {
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
    public ItemObject item;
    public int amount;
    public InventorySlot(int ID, ItemObject item, int amount)
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

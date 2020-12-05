using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ScriptableObject
{
    public ItemDatabaseObject database;
    public List<InventorySlot> Container = new List<InventorySlot>();

    public void AddItem(ItemObject item, int amount)
    {
        for(int i = 0; i < Container.Count; i++)
        {
            if(Container[i].item == item)
            {
                Container[i].AddAmount(amount);
                return;
            }
        }
        Container.Add(new InventorySlot(item, amount));
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }
}

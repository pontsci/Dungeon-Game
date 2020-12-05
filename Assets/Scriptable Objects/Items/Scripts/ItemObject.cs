using UnityEngine;

public enum ItemType
{
    Food,
    BadFood,
    Equipment,
    Gold,
    Potion,
    Default
}

public enum Attributes
{
    Agility,
    Intellect,
    Stamina,
    Strength
}


public class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay; //sprite to use for UI
    public ItemType type; //the item type
    [TextArea(15,20)]
    public string description; //item description
    public ItemBuff[] buffs;

    public Item CreateItem()
    {
        return new Item(this);
    }
}

[System.Serializable]
public class Item
{
    public string name;
    public int ID;
    public ItemBuff[] buffs;
    public Item(ItemObject item)
    {
        name = item.name;
        ID = item.ID;
        buffs = new ItemBuff[item.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);
            buffs[i].attribute = item.buffs[i].attribute;
        }
    }
}

[System.Serializable]
public class ItemBuff
{
    public Attributes attribute;
    public int value;
    public int min;
    public int max;
    public ItemBuff(int min, int max)
    {
        this.min = min;
        this.max = max;
        GenerateValue();
    }

    public void GenerateValue()
    {
        value = UnityEngine.Random.Range(min, max);
    }
}

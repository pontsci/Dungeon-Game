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
    public GameObject prefab;
    public ItemType type; //the item type
    [TextArea(15,20)]
    public string description; //item description
    public int restoreHungerValue;
    public float poisonChance;

    public virtual Item CreateItem()
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
    public int restoreHungerValue;
    public float poisonChance;
    public Item(ItemObject item)
    {
        if(item.type == ItemType.Food)
        {
            restoreHungerValue = item.restoreHungerValue;
        }
        if (item.type == ItemType.BadFood)
        {
            restoreHungerValue = item.restoreHungerValue;
            poisonChance = item.poisonChance;
        }
        name = item.name;
        ID = item.ID;
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

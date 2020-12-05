using System.Collections;
using System.Collections.Generic;
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
public class ItemObject : ScriptableObject
{
    public int ID;
    public Sprite uiDisplay; //sprite to use for UI
    public ItemType type; //the item type
    [TextArea(15,20)]
    public string description; //item description
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    Trap,
    Default
}

public class WorldObject : ScriptableObject
{
    public ObjectType type;
    [TextArea(15, 20)]
    public string description;
}

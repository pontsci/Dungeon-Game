using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trap Object", menuName = "World/Trap")]
public class TrapObject : WorldObject
{
    public int removeHealthValue;
    private void Awake()
    {
        type = ObjectType.Trap;
    }
}

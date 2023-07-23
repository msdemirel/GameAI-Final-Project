using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Inherit this class to create items that work with the inventory system
/// </summary>
public abstract class InventoryItem : ScriptableObject
{
    [SerializeField] private int _stackSize = 10;
    public int StackSize => _stackSize;
}

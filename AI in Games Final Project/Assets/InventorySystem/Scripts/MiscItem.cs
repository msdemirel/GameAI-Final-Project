using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to create miscellaneous items in the game
/// </summary>
[CreateAssetMenu(fileName = "Misc", menuName = "ScriptableObjects/MiscItem")]
public class MiscItem : InventoryItem
{
    public const ItemType Type = ItemType.MiscItem;
}

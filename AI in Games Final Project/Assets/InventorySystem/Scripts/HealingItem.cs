using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that is used to create healing items in the game
/// </summary>
[CreateAssetMenu(fileName = "Potion", menuName = "ScriptableObjects/HealingItem")]
public class HealingItem : InventoryItem
{
    public const ItemType Type = ItemType.HealingItem;
    [SerializeField] private float _healingAmount = 5f;
    public float HealingAmount => _healingAmount;
}

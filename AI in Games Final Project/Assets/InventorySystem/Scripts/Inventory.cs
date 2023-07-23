using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    /// <summary>
    /// Represents a single slot in the inventory
    /// </summary>
    [System.Serializable]
    private struct Slot
    {
        public InventoryItem item; // Which item is currently placed in this slot
        public int Quantity; // How many of them are in the slot
    }

    [SerializeField] private Slot[] Slots; // Represents all the inventory slots of this inventory

    // Called in the editor when a script is loaded or a value is changed in the inspector
    private void OnValidate()
    {
        // Make sure that the amount of items in each inventory slot is valid
        if (Slots != null)
        {
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i].item != null)
                {
                    if (Slots[i].Quantity < 1)
                    {
                        Slots[i].Quantity = 1;
                    }
                    else if (Slots[i].Quantity > Slots[i].item.StackSize)
                    {
                        Slots[i].Quantity = Slots[i].item.StackSize;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Stores an item in the inventory
    /// </summary>
    /// <param name="item">The item to store in the inventory</param>
    /// <returns>True if there was space for the item in the inventory, otherwise false</returns>
    public bool Store(InventoryItem item)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].item != null && Slots[i].item.GetHashCode() == item.GetHashCode() && Slots[i].Quantity < Slots[i].item.StackSize)
            {
                Slots[i].Quantity++;
                return true;
            }
        }
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].item == null)
            {
                Slots[i].item = item;
                Slots[i].Quantity = 1;
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Get an item from the inventory
    /// </summary>
    /// <param name="item">Returned item</param>
    /// <param name="hashCode">The HashCode of the item you want to retrieve</param>
    /// <returns>True if item with the same hashCode exists in the inventory</returns>
    public bool Retrieve(out InventoryItem item, int hashCode)
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].item != null && Slots[i].item.GetHashCode() == hashCode)
            {
                item = Slots[i].item;
                Slots[i].Quantity--;

                if (Slots[i].Quantity == 0)
                {
                    Slots[i].item = null;
                }

                return true;
            }
        }

        item = null;
        return false;
    }

    /// <summary>
    /// Check if the item exists in the inventory
    /// </summary>
    /// <param name="hashCode">The HashCode of the item to find</param>
    /// <returns></returns>
    public bool ItemExists(int hashCode)
    {
        foreach (Slot itemSlot in Slots)
        {
            if (itemSlot.item != null && itemSlot.item.GetHashCode() == hashCode)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Check if the item exists in the inventory
    /// </summary>
    /// <param name="item">The item to find</param>
    /// <returns></returns>
    public bool ItemExists(InventoryItem item)
    {
        foreach (Slot itemSlot in Slots)
        {
            if (itemSlot.item != null && itemSlot.item.GetHashCode() == item.GetHashCode())
            {
                return true;
            }
        }
        return false;
    }
}

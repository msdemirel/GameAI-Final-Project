using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Example class for demonstrating how to use the inventory
/// </summary>
public class InventoryExample : MonoBehaviour
{
    [SerializeField] HealingItem potion;
    [SerializeField] private float hp = 100f;
    private Inventory inventory;


    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (hp < 50f)
        {
            if (inventory.Retrieve(out InventoryItem item, potion.GetHashCode()))
            {
                Debug.Log("Health below 50. Healing using a potion from the inventory");
                hp += ((HealingItem)item).HealingAmount;
            }
            else
            {
                Debug.Log("Health below 50 but no potions in inventory");
            }
        }

        hp -= Time.deltaTime * 10f;
    }


}

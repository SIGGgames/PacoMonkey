using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour {
    public Item item;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // Add the item to the player's inventory
            other.GetComponent<InventoryManager>().AddItem(item);
            // Destroy the item object in the world
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {
    public List<Item> inventory = new List<Item>();

    public void AddItem(Item item) {
        inventory.Add(item);
    }

    public void RemoveItem(Item item) {
        inventory.Remove(item);
    }


    public void RemoveItem(int index) {
        inventory.RemoveAt(index);
    }

    public void RemoveAllItems() {
        inventory.Clear();
    }

    // This is just for debugging
    public void PrintItems() {
        foreach (Item item in inventory) {
            Debug.Log("[" + item.itemID + "] " + item.itemName);
        }
    }
}
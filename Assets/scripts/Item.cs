using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string itemName;
    public int itemID;

    public string itemDescription;
    // public Sprite itemIcon;
    // public GameObject itemModel;
    // TODO: Add item type

    public Item(string name, int id, string description) {
        itemName = name;
        itemID = id;
        itemDescription = description;
        // itemIcon = Resources.Load<Sprite>("Sprites/Items/" + name);
        // itemModel = Resources.Load<GameObject>("Prefabs/Items/" + name);
    }
}
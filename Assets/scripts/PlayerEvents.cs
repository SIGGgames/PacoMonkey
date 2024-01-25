using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEvents : MonoBehaviour {
    private Health playerHealth;
    private GameMaster gm;
    private InventoryManager inventoryManager;
    private Item item_test;

    // Start is called before the first frame update
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        playerHealth = GetComponent<Health>();
        inventoryManager = GetComponent<InventoryManager>();
        item_test = new Item("Name of the item test", 1, "Made the item with id 1");
    }

    // Update is called once per frame
    void Update() {
        // Set it on R to test the death, remove it later
        if (Input.GetKeyDown(KeyCode.R)) {
            playerHealth.TakeDamage();
        }

        // Set it on H to test the heal, remove it later
        if (Input.GetKeyDown(KeyCode.H)) {
            playerHealth.Heal();
        }

        /*
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("MainMenu");
        }
        */

        if (Input.GetKeyDown(KeyCode.G)) {
            if (Utils.IsNotNull(item_test) && Utils.IsNotNull(inventoryManager)) {
                inventoryManager.AddItem(item_test);
            }
        }
    }

    /**
     * Respawn(): Respawns the player at the last checkpoint
     */
    public static void Respawn() {
        // The player health is reset in the Start() method of Health.cs
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
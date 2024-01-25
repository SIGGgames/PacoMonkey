using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerEvents : MonoBehaviour {
    private Health playerHealth;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        playerHealth = GetComponent<Health>();
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
    }

    /**
     * Respawn(): Respawns the player at the last checkpoint
     */
    public static void Respawn() {
        // The player health is reset in the Start() method of Health.cs
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
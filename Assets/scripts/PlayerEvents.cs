using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour {
    [SerializeField] public int playerHealth = 3;

    private const int _defaultPlayerHealth = 3;
    private GameMaster gm;

    // Start is called before the first frame update
    void Start() {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update() {
        CheckDeath();

        // Set it on R to test the death, remove it later
        if (Input.GetKeyDown(KeyCode.R)) {
            DecreaseHealth();
        }
    }

    /**
     * Respawn(): Respawns the player at the last checkpoint
     */
    private void Respawn() {
        transform.position = gm.lastCheckPointPosition;
    }

    /**
     * CheckDeath(): Checks if the player has died and respawns it
     */
    private void CheckDeath() {
        if (IsPlayerDeath()) {
            Respawn();
            playerHealth = _defaultPlayerHealth;
        }
    }

    /**
     * DecreaseHealth(): Decreases the player's health
     */
    private void DecreaseHealth(int amount = 1) {
        playerHealth -= amount;
        CheckDeath();
    }

    private bool IsPlayerDeath() {
        return playerHealth <= 0;
    }
}
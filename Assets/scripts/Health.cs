using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    [SerializeField] public int maxHealth = 3;
    [SerializeField] public int currentHealth;


    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
    }

    /**
     * TakeDamage(): Decreases the player's health
     */
    public void TakeDamage(int amount = 1) {
        currentHealth -= amount;
        if (currentHealth <= 0) {
            // TODO: Add player death animation
            // TODO: Show game over screen
            PlayerEvents.Respawn();
        }
    }

    /**
     * Heal(): Increases the player's health
     */
    public void Heal(int amount = 1) {
        currentHealth += amount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}
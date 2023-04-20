using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth2 : MonoBehaviour
{
    public int maxHealth = 100;  // maximum health of the player
    public int currentHealth;   // current health of the player

    void Start()
    {
        currentHealth = maxHealth;  // set the current health to maximum health at the start of the game
    }

    void Update()
    {
        // Check if the player's health has reached zero
        if (currentHealth <= 0)
        {
            // Player is dead, do something
        }
    }

    // Function to reduce the player's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;  // reduce the current health by the damage amount

        // Clamp the current health value between 0 and maxHealth
        currentHealth = Mathf.Clamp(currentHealth, -666, maxHealth);
    }

    // Function to increase the player's health
    public void Heal(int amount)
    {
        currentHealth += amount;  // increase the current health by the amount

        // Clamp the current health value between 0 and maxHealth
        currentHealth = Mathf.Clamp(currentHealth, -666, maxHealth);
    }
}

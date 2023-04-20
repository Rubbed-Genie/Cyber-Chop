using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public delegate void HealthChangedDelegate(int currentHealth, int maxHealth);
    public event HealthChangedDelegate OnHealthChanged;  // event that is fired when the health changes

    [SerializeField] private int maxHealth = 100;  // maximum health of the player
    [SerializeField] private int currentHealth;   // current health of the player

    public int MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value; }
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
        set
        {
            currentHealth = Mathf.Clamp(value, -666, maxHealth);  // clamp the current health value between 0 and maxHealth
            OnHealthChanged?.Invoke(currentHealth, maxHealth);  // fire the OnHealthChanged event
        }
    }

    void Start()
    {
        CurrentHealth = maxHealth;  // set the current health to maximum health at the start of the game
    }

    // Function to reduce the player's health
    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;  // reduce the current health by the damage amount
    }

    // Function to increase the player's health
    public void Heal(int amount)
    {
        CurrentHealth += amount;  // increase the current health by the amount
    }

       private void OnValidate()
    {
        // Trigger the OnHealthChanged event to update the health text in the editor
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Text healthText;

    void Start()
    {
        // Subscribe to the OnHealthChanged event to update the health text whenever the player's health changes
        playerHealth.OnHealthChanged += UpdateHealthText;

        // Initialize the health text with the current health
        UpdateHealthText(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }

    void OnDestroy()
    {
        // Unsubscribe from the OnHealthChanged event to prevent memory leaks
        playerHealth.OnHealthChanged -= UpdateHealthText;
    }

    void UpdateHealthText(int currentHealth, int maxHealth)
    {
    // Update the health text with the current health value
    healthText.text = currentHealth.ToString();
    }
}

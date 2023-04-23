using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Text healthText;
    [SerializeField] private EnemySystem enemySystem;
    [SerializeField] private Text scoreText;

    void Start()
    {
        // Subscribe to the OnHealthChanged event to update the health text whenever the player's health changes
        playerHealth.OnHealthChanged += UpdateHealthText;
        enemySystem.OnScoreChanged += UpdateScoreText;


        // Initialize the health text with the current health
        UpdateHealthText(playerHealth.CurrentHealth, playerHealth.MaxHealth);


        UpdateScoreText(enemySystem.currentScore);

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


    void UpdateScoreText(int currentScore)
    {
    scoreText.text = currentScore.ToString();
    }
}

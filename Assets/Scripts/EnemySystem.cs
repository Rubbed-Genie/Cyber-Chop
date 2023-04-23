using UnityEngine;
using System.Collections.Generic;

public class EnemySystem : MonoBehaviour 
{
    public delegate void EnemyChangedDelegate(int currentScore);
    public event EnemyChangedDelegate OnScoreChanged;  
    public int currentScore = 0;

    public int CurrentScore
    {
            get { return currentScore; }
            set
            {
             currentScore = value;
             OnScoreChanged?.Invoke(currentScore);  
            }
    }
   
    void Start()
    {
        CurrentScore = currentScore;  // set the current health to maximum health at the start of the game
    }

    public void EnemyDefeated()
    {
        // Called when an enemy is defeated
        CurrentScore++;

    }
}

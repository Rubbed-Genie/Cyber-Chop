using UnityEngine;
using UnityEngine.UI;
using System;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 60.0f; // Starting amount of time in seconds
    public Text countdownText; // Reference to a UI Text component to display the countdown

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;

        // Convert the time remaining to a TimeSpan to get the milliseconds component
        TimeSpan timeSpan = TimeSpan.FromSeconds(timeRemaining);

        // Update the UI Text component with the remaining time (including milliseconds)
        countdownText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

        // If time has run out, do something (e.g. end the game)
        if (timeRemaining <= 0)
        {
            // Do something here
        }
    }

    // Adds the given amount of time to the countdown
    public void AddTime(float timeToAdd)
    {
        timeRemaining += timeToAdd;
    }
}

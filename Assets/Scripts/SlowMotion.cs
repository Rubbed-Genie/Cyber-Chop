using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    // Public variable for adjusting the time scale
    public float timeScale = 0.5f;

    void Update()
    {
        // Detect mouse scroll input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Adjust time scale based on input
        if (scroll != 0f)
        {
            timeScale += scroll * 0.1f;
            timeScale = Mathf.Clamp(timeScale, 0.1f, 1f);
        }

        // Apply the time scale to the game
        Time.timeScale = timeScale;

        // Adjust fixed delta time based on time scale
        Time.fixedDeltaTime = 0.02f * timeScale;
    }
}

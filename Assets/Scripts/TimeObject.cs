using UnityEngine;

public class TimeObject : MonoBehaviour
{
    // Reference to the script containing the AddTime function
    public CountdownTimer timeController;
    public GameObject Clock;
    public CharacterController controller;
    public float X = 10f;
    // Triggered when the character controller collides with this object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the character controller
        if (other.gameObject == controller.gameObject)
        {
            // Call the AddTime function from the TimeController script
            timeController.AddTime(X);
            Clock.SetActive(false);
        }
    }
}


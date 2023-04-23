using UnityEngine;

public class Console : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Camera gameCamera;

    void Update()
    {
        if (playerHealth.CurrentHealth == 0)
        {
            gameCamera.depth = 1;
        }
    }
}
using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10.0f;  // amount of damage the enemy will deal
    [SerializeField] private string destroyTag = "Hand";  // tag of the object that will destroy the enemy
    [SerializeField] private PlayerHealth playerHealth;
    public CharacterController controller;
    public bool isColliding = false;
    public GameObject Head;

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject == controller.gameObject)
        {
            isColliding = true;
            // If the enemy collides with the controller, deal damage to the player
            if (playerHealth != null)
            {
                float damagePerSecond = damageAmount / Time.deltaTime; // calculate damage per second
                float damagePerFrame = damagePerSecond * Time.fixedDeltaTime; // calculate damage per fixed frame
                int damagePerFrameInt = (int)damagePerFrame; // convert to integer value
                playerHealth.TakeDamage(damagePerFrameInt); // damage every fixed frame
                Debug.Log("Player took " + damagePerFrameInt + " damage from enemy");
            }
        }
        else if (other.CompareTag(destroyTag))
        {
            // If the enemy collides with an object with the specified tag, destroy itself
            Destroy(Head);
            Debug.Log("Enemy destroyed by object with tag " + destroyTag);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == controller.gameObject)
        {
            isColliding = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporttt : MonoBehaviour
{
    public CharacterController controller;
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the character controller
        if (other.gameObject == controller.gameObject)
        {
            // Teleport the character to the destination
            controller.enabled = false;
            controller.transform.position = destination.position;
            controller.transform.rotation = destination.rotation; // Set the rotation of the character controller to the rotation of the destination object
            controller.enabled = true;
        }
    }
}

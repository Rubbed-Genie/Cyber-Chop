using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporttt : MonoBehaviour
{
    public CharacterController controller;
    public Transform[] destinations;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the character controller
        if (other.gameObject == controller.gameObject)
        {
            // Teleport the character to a random destination from the array
            Transform destination = destinations[Random.Range(0, destinations.Length)];
            controller.enabled = false;
            controller.transform.position = destination.position;
            controller.transform.rotation = destination.rotation;
            controller.enabled = true;
        }
    }
}

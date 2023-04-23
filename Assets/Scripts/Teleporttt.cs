using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporttt : MonoBehaviour
{
    public CharacterController controller;
    public Transform[] destinations;
    public float teleportDelay = 1f; // The time in seconds the character has to stay on the teleporter before being teleported

    private bool isOnTeleporter = false;
    private float timeOnTeleporter = 0f;

    private void OnTriggerStay(Collider other)
    {
        // Check if the collider belongs to the character controller
        if (other.gameObject == controller.gameObject)
        {
            isOnTeleporter = true;
            timeOnTeleporter += Time.deltaTime;

            // Teleport the character to a random destination from the array if they've stayed on the teleporter long enough
            if (timeOnTeleporter >= teleportDelay)
            {
                Transform destination = destinations[Random.Range(0, destinations.Length)];
                controller.enabled = false;
                controller.transform.position = destination.position;
                controller.transform.rotation = destination.rotation;
                controller.enabled = true;

                // Reset the timer and flag
                timeOnTeleporter = 0f;
                isOnTeleporter = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == controller.gameObject)
        {
            // Reset the timer and flag
            timeOnTeleporter = 0f;
            isOnTeleporter = false;
        }
    }
}

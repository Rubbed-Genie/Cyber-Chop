using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportt : MonoBehaviour
{
    public CharacterController controller;
    public Transform destination;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the character controller
        if (other.gameObject == controller.gameObject)
        {
            // Teleport the character to the destination using the Move method
            controller.enabled = false;
            controller.transform.position = destination.position;
            controller.transform.rotation = destination.rotation;
            controller.enabled = true;
        }
    }
}

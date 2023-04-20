using System.Collections.Generic;
using UnityEngine;

public class Legs : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public bool canRun = true;
    public float runSpeed = 9f;
    public float ClickSpeed = 7f;
    public KeyCode runningKey = KeyCode.LeftShift;

    private Transform playerTransform;
    private CharacterController characterController;
    private bool isRunning;
    private List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    private void Awake()
    {
        playerTransform = transform;
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        isRunning = canRun && Input.GetKey(runningKey);
    }

    private void FixedUpdate()
    {
        float targetMovingSpeed = isRunning ? runSpeed : speed;

        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        Vector3 targetVelocity = Vector3.zero;
        if (Input.GetButton("Fire2"))
        {
            targetVelocity = playerTransform.forward * ClickSpeed;
        }
        else
        {
            targetVelocity = playerTransform.right * Input.GetAxis("Horizontal") + playerTransform.forward * Input.GetAxis("Vertical");
            targetVelocity = targetVelocity.normalized * targetMovingSpeed;
        }

        characterController.SimpleMove(targetVelocity);
    }

    public void AddSpeedOverride(System.Func<float> speedOverride)
    {
        speedOverrides.Add(speedOverride);
    }

    public void RemoveSpeedOverride(System.Func<float> speedOverride)
    {
        speedOverrides.Remove(speedOverride);
    }
}

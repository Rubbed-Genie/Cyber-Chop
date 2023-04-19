using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    CharacterController controller;
    public float jumpStrength = 2;
    public float gravity = -9.81f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;

    float yVelocity = 0;

    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void LateUpdate()
    {
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            yVelocity = Mathf.Sqrt(-2 * gravity * jumpStrength);
            Jumped?.Invoke();
        }

        yVelocity += gravity * Time.deltaTime;

        if (yVelocity < 0)
        {
            yVelocity += gravity * Time.deltaTime * fallMultiplier;
        }
        else if (yVelocity > 0 && !Input.GetButton("Jump"))
        {
            yVelocity += gravity * Time.deltaTime * lowJumpMultiplier;
        }

        Vector3 velocity = new Vector3(0, yVelocity, 0);
        controller.Move(velocity * Time.deltaTime);
    }
}

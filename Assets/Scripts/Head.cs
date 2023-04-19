using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour
{
    [Header("Mouse Settings")]
    [SerializeField] private float sensitivity = 2f;
    [SerializeField] private float smoothing = 1.5f;

    [Header("Player Settings")]
    [SerializeField] private Transform character;

    private Vector2 velocity;
    private Vector2 frameVelocity;
    private Legs Legs;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Legs = GetComponentInParent<Legs>();
    }

    private void Reset()
    {
        character = Legs.transform;
    }

    private void Update()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Vector2 rawFrameVelocity = Vector2.Scale(mouseDelta, Vector2.one * sensitivity);
        frameVelocity = Vector2.Lerp(frameVelocity, rawFrameVelocity, 1 / smoothing);
        velocity += frameVelocity * Time.deltaTime;
        velocity.y = Mathf.Clamp(velocity.y, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(-velocity.y, Vector3.right);
        character.localRotation = Quaternion.AngleAxis(velocity.x, Vector3.up);
    }
}

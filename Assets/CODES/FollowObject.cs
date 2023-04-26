using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;

    private void Update()
    {
        transform.position = objectToFollow.position;
        transform.rotation = objectToFollow.rotation;
    }
}

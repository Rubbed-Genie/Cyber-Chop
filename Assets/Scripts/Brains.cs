using UnityEngine;

public class Brains : MonoBehaviour
{
    public Transform target;
    public float speed = 2.0f;
    public float stoppingDistance = 1.0f;
    public float maxDistance = 10.0f;

    private bool canSeeTarget = false;

    void Update()
    {
        if (target == null) return;

        // Check if the target is within max distance
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance > maxDistance) return;

        // Check if the target is within line of sight
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, target.position - transform.position, out hitInfo, maxDistance))
        {
            if (hitInfo.collider.gameObject == target.gameObject)
            {
                canSeeTarget = true;
            }
            else
            {
                canSeeTarget = false;
            }
            Debug.DrawRay(transform.position, target.position - transform.position, canSeeTarget ? Color.green : Color.red);
        }



        // If the target is within range and visible, move towards it
        if (canSeeTarget && distance > stoppingDistance)
        {
            transform.LookAt(target);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}

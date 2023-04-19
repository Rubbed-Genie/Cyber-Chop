using UnityEngine;
using System.Collections;

public class HandShooter : MonoBehaviour
{
    public float shootingForce = 1000f; // Adjust this to control the shooting force of the hand
    public GameObject bulletPrefab; // Assign the bullet prefab to this variable in the inspector

    private bool isFiring = false;

    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && !isFiring)
        {
            Fire();
        }
    }

    void Fire()
    {
        isFiring = true;

        // Instantiate a new bullet from the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

        // Add a force to the bullet to propel it forward
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.AddForce(transform.forward * shootingForce);
        }

        // Wait for a short duration before allowing the player to fire again
        StartCoroutine(ResetFiring());
    }

    IEnumerator ResetFiring()
    {
        yield return new WaitForSeconds(0.5f);
        isFiring = false;
    }
}

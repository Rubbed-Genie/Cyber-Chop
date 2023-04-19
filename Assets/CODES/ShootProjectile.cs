using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject projectilePrefab; // The prefab for the spinning 3D object
    public Transform shooterTransform; // The transform of the shooter object
    public float projectileSpeed = 10f; // The speed at which the projectile will move forward
    public float projectileLifetime = 5f; // The time before the projectile will disappear
    public float regenTime = 1f; // The time until the player can shoot again
    public Renderer objectRenderer; // The renderer of the object whose material will change
    public Material shootingMaterial; // The material to change to when the player shoots

    private float nextFireTime = 0f; // The time when the player can shoot again
    private Material defaultMaterial; // The default material of the objectRenderer

    private void Start()
    {
        defaultMaterial = objectRenderer.material; // Store the default material
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            GameObject newProjectile = Instantiate(projectilePrefab, shooterTransform.position, shooterTransform.rotation);
            newProjectile.GetComponent<Rigidbody>().velocity = shooterTransform.forward * projectileSpeed;
            Destroy(newProjectile, projectileLifetime);

            nextFireTime = Time.time + regenTime; // Set the time when the player can shoot again

            StartCoroutine(ChangeMaterial()); // Start the coroutine to change the material of the objectRenderer
        }
    }

    private IEnumerator ChangeMaterial()
    {
        objectRenderer.material = shootingMaterial; // Change the material of the objectRenderer to shootingMaterial
        yield return new WaitForSeconds(regenTime); // Wait for the regenTime
        objectRenderer.material = defaultMaterial; // Change the material of the objectRenderer back to the defaultMaterial
    }
}


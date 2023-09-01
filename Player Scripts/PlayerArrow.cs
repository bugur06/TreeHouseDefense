using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArrow : MonoBehaviour
{

    [SerializeField]
    private GameObject arrowPrefab; // Prefab of the arrow projectile

    private Transform firePoint;   // Point where the arrows will be spawned
    private float arrowSpeed = 10f; // Speed of the arrow
    private LayerMask targetLayer; // Layer mask to determine what the arrow can hit
    private Camera mainCamera;     // Main camera of the scene
    private AudioSource audioSource;

    void Update()
    {
        // Check for mouse input
        if (Input.GetButtonDown("Fire1")) // You can customize the input button
        {
            ShootArrow();
        }
    }


    private void Awake()
    {

        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;

        firePoint = transform.Find("FirePoint");

    }

    void ShootArrow()
    {
        // Calculate direction from player to mouse cursor
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shootDirection = mousePosition - firePoint.position;
        shootDirection.z = 0f;
        shootDirection.Normalize();

        // Create the arrow
        GameObject newArrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);

        // Rotate the arrow to face the shooting direction
        float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
        newArrow.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Add force to the arrow
        Rigidbody2D rb = newArrow.GetComponent<Rigidbody2D>();
        rb.velocity = shootDirection * arrowSpeed;

        // Destroy the arrow after some time (adjust as needed)
        Destroy(newArrow.gameObject, 5f);

        
    }





}

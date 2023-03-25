using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public GameObject player;
    public GameManager gameManager;
    private Rigidbody prb;
    // Floating speed
    public float speed = 1f;

    // Floating range
    public float range = 0.5f;

    // Rotation speed
    public float rotationSpeed = 50f;

    // Starting position
    private Vector3 startPos;

    // Starting rotation
    private Quaternion startRot;

    // Float the object up and down and rotate it in a circle
    private void FixedUpdate()
    {
        // Calculate new position
        Vector3 newPosition = startPos;
        newPosition.y += Mathf.Sin(Time.time * speed) * range;

        // Calculate new rotation
        Quaternion newRotation = startRot;
        newRotation *= Quaternion.Euler(Vector3.up * Time.time * rotationSpeed);

        // Apply new position and rotation
        transform.position = newPosition;
        transform.rotation = newRotation;
    }

    // Initialize starting position and rotation
    private void Start()
    {
        prb = player.GetComponent<Rigidbody>();
        startPos = transform.position;
        startRot = transform.rotation;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the trigger was entered by an object tagged as "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Disable the current game object
            gameObject.SetActive(false);
            gameManager.DiamondSwitch(this.gameObject);
        }
    }
}

using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f; // Adjust this value to control the speed of movement
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        // Cast a ray in the direction of movement to check for collisions with walls
        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement, out hit, 0.5f))
        {
            // If the ray hits a wall, move the object back so it doesn't pass through the wall
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = hit.point - movement.normalized * 0.5f;
        }
    }
}
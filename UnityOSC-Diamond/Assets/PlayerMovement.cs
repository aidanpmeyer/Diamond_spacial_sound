using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rayDistance = 1f;
    public bool useAlternativeKeys = false;

    private Rigidbody rb;
    private KeyCode leftKey = KeyCode.A;
    private KeyCode rightKey = KeyCode.D;
    private KeyCode upKey = KeyCode.W;
    private KeyCode downKey = KeyCode.S;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (useAlternativeKeys)
        {
            leftKey = KeyCode.J;
            rightKey = KeyCode.L;
            upKey = KeyCode.I;
            downKey = KeyCode.K;
        }
    }

    void FixedUpdate()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(leftKey))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(rightKey))
        {
            moveX = 1f;
        }

        if (Input.GetKey(upKey))
        {
            moveZ = 1f;
        }
        else if (Input.GetKey(downKey))
        {
            moveZ = -1f;
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ);

        rb.MovePosition(transform.position + movement * speed * Time.fixedDeltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, movement, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                rb.MovePosition(transform.position + (movement * speed * Time.fixedDeltaTime * hit.distance / rayDistance));
            }
        }
    }

  
}
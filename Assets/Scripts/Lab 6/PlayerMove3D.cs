using UnityEngine;

public class PlayerMove3D : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal"); // A, D
        float v = Input.GetAxis("Vertical");   // W, S

        Vector3 move = new Vector3(h, 0, v);
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}

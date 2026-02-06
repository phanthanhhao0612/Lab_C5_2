using UnityEngine;

public class ForcePushObject : MonoBehaviour
{
    public float force = 500f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.forward * force);
        }
    }
}

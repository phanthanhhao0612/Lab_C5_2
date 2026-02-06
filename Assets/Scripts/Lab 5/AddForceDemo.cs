using UnityEngine;

public class AddForceDemo : MonoBehaviour
{
    public float forcePower = 500f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * forcePower);
        }
    }
}

using UnityEngine;

public class ConveyorBelt3D : MonoBehaviour
{
    public Vector3 direction = Vector3.forward;
    public float speed = 2f;

    void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb != null)
        {
            rb.AddForce(direction.normalized * speed, ForceMode.VelocityChange);
        }

        CharacterController cc = collision.collider.GetComponent<CharacterController>();
        if (cc != null)
        {
            cc.Move(direction.normalized * speed * Time.deltaTime);
        }
    }
}

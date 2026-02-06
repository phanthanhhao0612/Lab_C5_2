using UnityEngine;

public class OneWayPlatform3D : MonoBehaviour
{
    Collider platformCol;

    void Start()
    {
        platformCol = GetComponent<Collider>();
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.contacts[0].normal.y < 0)
        {
            Physics.IgnoreCollision(collision.collider, platformCol, true);
        }
        else
        {
            Physics.IgnoreCollision(collision.collider, platformCol, false);
        }
    }
}

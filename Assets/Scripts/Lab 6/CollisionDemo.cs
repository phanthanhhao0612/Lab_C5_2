using UnityEngine;

public class CollisionDemo : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision với: " + collision.gameObject.name);
    }
}

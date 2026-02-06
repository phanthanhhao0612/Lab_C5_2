using UnityEngine;

public class TriggerDemo : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger với: " + other.gameObject.name);
    }
}

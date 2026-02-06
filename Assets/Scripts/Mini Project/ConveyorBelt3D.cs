using UnityEngine;

public class ConveyorBelt_CC : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.forward;
    public float speed = 2f;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        CharacterController controller = hit.controller;

        // Chỉ đẩy khi đứng trên mặt băng chuyền
        if (Vector3.Dot(hit.normal, Vector3.up) > 0.5f)
        {
            Vector3 move = moveDirection.normalized * speed * Time.deltaTime;
            controller.Move(move);
        }
    }
}

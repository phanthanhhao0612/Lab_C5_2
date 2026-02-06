using UnityEngine;

public class PlayerCCMove_FIXED : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = (transform.right * h + transform.forward * v) * speed;

        // Nếu đang đứng đất → KHÓA Y
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;

        // MOVE DUY NHẤT 1 LẦN
        controller.Move((move + velocity) * Time.deltaTime);
    }
}

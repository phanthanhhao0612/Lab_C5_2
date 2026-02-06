using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Cài đặt Di chuyển")]
    public float speed = 6f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    [Header("Cài đặt Tương tác")]
    public float pushPower = 2.0f;     // Lực đẩy hộp
    public float conveyorSpeed = 3.0f; // Tốc độ bị băng chuyền đẩy

    [Header("Kiểm tra mặt đất")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // --- 1. Xử lý Trọng lực & Nhảy ---
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // --- 2. Xử lý Di chuyển WASD ---
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Nhảy
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Áp dụng trọng lực rơi
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // --- 3. Xử lý Va chạm (Đẩy hộp & Băng chuyền) ---
    // Hàm này tự động chạy khi CharacterController chạm vào bất cứ thứ gì
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // A. XỬ LÝ BĂNG CHUYỀN (CONVEYOR)
        // Nếu vật dưới chân có Tag là "Conveyor"
        if (hit.gameObject.CompareTag("Conveyor"))
        {
            // Kiểm tra xem có đang đứng lên mặt trên của nó không (tránh chạm cạnh bên)
            if (hit.moveDirection.y < -0.3f)
            {
                // Lấy hướng trục Z (Forward) của băng chuyền
                Vector3 pushDirection = hit.transform.forward;

                // Đẩy nhân vật đi theo hướng đó
                controller.Move(pushDirection * conveyorSpeed * Time.deltaTime);
            }
        }

        // B. XỬ LÝ ĐẨY HỘP (RIGIDBODY)
        Rigidbody body = hit.collider.attachedRigidbody;

        // Nếu vật va chạm có Rigidbody và không bị khóa cứng
        if (body != null && !body.isKinematic)
        {
            // Không đẩy nếu đang đứng lên nó (chỉ đẩy ngang)
            if (hit.moveDirection.y < -0.3f) return;

            // Tính lực đẩy
            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
            body.linearVelocity = pushDir * pushPower;
        }
    }
}
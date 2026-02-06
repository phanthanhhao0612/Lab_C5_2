using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private Collider platformCollider;
    private Collider playerCollider;

    void Start()
    {
        platformCollider = GetComponent<Collider>();

        // Tìm Player
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            playerCollider = playerObj.GetComponent<Collider>();

            // CHIẾN THUẬT: Mặc định TẮT VA CHẠM (Xuyên qua) ngay từ đầu
            Physics.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }

    void Update()
    {
        if (playerCollider == null) return;

        // 1. Lấy vị trí GÓT CHÂN nhân vật
        float gotChan = playerCollider.bounds.min.y;

        // 2. Lấy vị trí MẶT SÀN trên cùng
        float matSan = platformCollider.bounds.max.y;

        // 3. LOGIC QUYẾT ĐỊNH:
        // Chỉ BẬT lại va chạm (Hóa đá) khi: Gót chân đã nằm HẲN lên trên mặt sàn
        // (Cộng thêm 0.05f để tạo vùng đệm an toàn, tránh bị nhấp nháy khi đứng mép)

        bool daLeoLenTren = gotChan > (matSan - 0.05f);

        if (daLeoLenTren)
        {
            // Đã ở trên -> BẬT va chạm (để đứng)
            Physics.IgnoreCollision(platformCollider, playerCollider, false);
        }
        else
        {
            // Còn lại (đang ở dưới, đang nhảy, đang lơ lửng) -> TẮT va chạm (xuyên qua)
            Physics.IgnoreCollision(platformCollider, playerCollider, true);
        }
    }
}
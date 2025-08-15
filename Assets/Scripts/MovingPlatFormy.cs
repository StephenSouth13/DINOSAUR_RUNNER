using UnityEngine;

public class MovingPlatformy : MonoBehaviour
{
    [Header("Platform Movement")]
    [SerializeField] private float speed = 1.0f;

    [Header("Target Positions")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private Vector3 targetPosition;

    void Start()
    {
        if (pointA == null || pointB == null)
        {
            Debug.LogError("Platform points A and B are not assigned. Please assign them in the Inspector.");
            enabled = false;
            return;
        }

        // Khởi đầu, nền tảng sẽ di chuyển tới điểm B
        targetPosition = pointB.position;
        Debug.Log("Platform starting. Current target is Point B.");
    }

    void Update()
    {
        // Di chuyển nền tảng tới vị trí mục tiêu
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Kiểm tra xem nền tảng đã đến VỊ TRÍ MỤC TIÊU một cách chính xác chưa
        if (transform.position == targetPosition)
        {
            // Nếu đã đến điểm B, thì chuyển mục tiêu về điểm A
            if (targetPosition == pointB.position)
            {
                targetPosition = pointA.position;
                Debug.Log("Reached Point B. Switching target to Point A.");
            }
            // Nếu đã đến điểm A, thì chuyển mục tiêu về điểm B
            else
            {
                targetPosition = pointB.position;
                Debug.Log("Reached Point A. Switching target to Point B.");
            }
        }
    }
}
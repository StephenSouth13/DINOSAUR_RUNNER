using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Platform Movement")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float travelDistance = 3.0f; // Khoảng cách di chuyển theo trục Y

    private Vector3 positionA;
    private Vector3 positionB;
    private Vector3 targetPosition;

    void Start()
    {
        // Vị trí ban đầu của nền tảng
        positionA = transform.position;

        // Vị trí mục tiêu thứ hai (Điểm B) được tính từ vị trí ban đầu
        positionB = new Vector3(positionA.x, positionA.y + travelDistance, positionA.z);

        // Ban đầu, nền tảng sẽ di chuyển đến điểm B
        targetPosition = positionB;
    }

    void Update()
    {
        // Di chuyển nền tảng tới vị trí mục tiêu
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Kiểm tra xem nền tảng đã đến vị trí mục tiêu chưa
        if (transform.position == targetPosition)
        {
            // Nếu đã đến điểm B, thì chuyển mục tiêu về điểm A
            if (targetPosition == positionB)
            {
                targetPosition = positionA;
            }
            // Nếu đã đến điểm A, thì chuyển mục tiêu về điểm B
            else
            {
                targetPosition = positionB;
            }
        }
    }
}
using UnityEngine;

public class MovingPlatformy : MonoBehaviour
{
    [Header("Platform Movement")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private Rigidbody2D rb;
    private Vector2 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null || pointA == null || pointB == null)
        {
            Debug.LogError("Missing required components or transforms on MovingPlatformy.");
            enabled = false;
            return;
        }

        rb.bodyType = RigidbodyType2D.Kinematic;
        targetPosition = pointB.position;
    }

    void FixedUpdate()
    {
        Vector2 newPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);

        if (Vector2.Distance(rb.position, targetPosition) < 0.05f)
        {
            if (targetPosition == (Vector2)pointB.position)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.SetOnPlatform(transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.RemoveFromPlatform();
            }
        }
    }
}
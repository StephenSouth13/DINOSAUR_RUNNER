using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        // Tìm GameManager trong scene
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name);

        // Nếu va chạm với coin
        if (collision.CompareTag("Coin"))
        {
            gameManager.AddScore(1);                       // Tăng điểm
            Debug.Log("Hit Coin");
            Destroy(collision.gameObject);                 // Xóa coin khỏi scene
        }
    }
}

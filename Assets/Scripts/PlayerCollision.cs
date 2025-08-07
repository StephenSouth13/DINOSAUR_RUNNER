using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided with: " + collision.name);

        if (collision.CompareTag("Coin"))
        {
            gameManager.AddScore(1);
            Debug.Log("Hit Coin");
            Destroy(collision.gameObject);
        }
    }
}

using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;                                  // Biến lưu điểm số

    public void AddScore(int points)
    {
        score += points;                                   // Cộng điểm
        Debug.Log("Score: " + score);                      // In ra điểm hiện tại
    }
}

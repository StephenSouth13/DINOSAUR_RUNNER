using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}

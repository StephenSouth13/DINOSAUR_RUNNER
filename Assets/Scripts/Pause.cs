using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0;
        AudioManager.Instance.PlaySFX("click");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        AudioManager.Instance.PlaySFX("click");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is quitting...");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioManager.Instance.PlaySFX("click");
    }
}

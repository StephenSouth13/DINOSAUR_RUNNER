using UnityEngine;
public class MainMenu : MonoBehaviour
{
    // Tham chiếu đến các đối tượng UI trong menu chính
    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject settingsMenuUI;

    private void Start()
    {
        // Hiển thị menu chính khi bắt đầu
        ShowMainMenu();
    }

    public void ShowMainMenu()
    {
        mainMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        mainMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }
    public void ResumeGame()
    {
        // Tiếp tục trò chơi
        Time.timeScale = 1;
        mainMenuUI.SetActive(false);
    }
    public void QuitGame()
    {
        // Thoát trò chơi
        Application.Quit();
        Debug.Log("Game is quitting...");
    }
    public void RestartGame()
    {
        // Khởi động lại trò chơi
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
}
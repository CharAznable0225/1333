using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject pauseMenuPanel;

    private bool isPaused = false;

    void Start()
    {
       
        mainMenuPanel.SetActive(true);
        pauseMenuPanel.SetActive(false);

        
        Time.timeScale = 0f;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); 
#endif
    }

    

    public void PauseGame()
    {
        pauseMenuPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
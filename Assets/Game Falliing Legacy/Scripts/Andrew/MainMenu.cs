using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] bool isPaused;
    [SerializeField] int pauseIndex;
    [SerializeField] string pauseActivate;
    [SerializeField] private GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
        pauseIndex = 1;
    }

    void Update()
    {
        if (Input.GetButtonDown(pauseActivate) && pauseIndex % 2 is 0)
        {
            Debug.Log("Paused");
            pauseIndex++;
            PauseGame();
        }

        else if (Input.GetButtonDown(pauseActivate) && pauseIndex % 2 is not 0)
        {
            Debug.Log("Unpaused");
            pauseIndex++;
            ResumeGame();
        }
    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Menu()
    {

        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        isPaused = true;
        pauseMenu.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pauseMenu.SetActive(false);
    }

}

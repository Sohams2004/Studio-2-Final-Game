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
        pauseIndex = 2;
    }

    void Update()
    {
        if (Input.GetButtonDown(pauseActivate) && pauseIndex % 2 is 0)
        {

            PauseGame();
            Debug.Log("Paused");
            pauseIndex++;
        }

        else if (Input.GetButtonDown(pauseActivate) && pauseIndex % 2 is not 0)
        {

            ResumeGame();
            Debug.Log("Unpaused");
            pauseIndex++;
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
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject DeathMenu;
    [SerializeField]
    private DeathScript DeathScript;
    [SerializeField]
    private GameObject PauseMenu;
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void RestartGame()
    {
        DeathMenu.SetActive(false);
        Time.timeScale = 1f;
        DeathScript.isPaused = false;
        SceneManager.LoadSceneAsync(0);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        DeathScript.isPaused = false;

    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(true);
        DeathScript.isPaused = true;
    }
}

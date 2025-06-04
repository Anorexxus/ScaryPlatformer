using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Settings;
    [SerializeField]
    private GameObject Credits;
    [SerializeField]
    private GameObject MainMenu;


    public void StartGame()
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex: 0);
    }
    public void OpenSettings()
    {
        Settings.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void OpenCredits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoBack1()
    {
        Settings.SetActive(false);
        MainMenu.SetActive(true);
    }
    public void GoBack2()
    {
        Credits.SetActive(false);
        MainMenu.SetActive(true);
    }
}

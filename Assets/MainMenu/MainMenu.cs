using UnityEngine;
using UnityEngine.Rendering;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _creditsMenu;
    [SerializeField] private GameObject _tutorialMenu;

    public void StartGame()
    {
        Debug.Log("Start");
    }
    public void ContinueGame()
    {
        Debug.Log("Continue");
    }
    public void Settings()
    {
       _settingsMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Credits()
    {
       _creditsMenu.SetActive(true);
    }
    public void Tutorial()
    {
        _tutorialMenu.SetActive(true);
    }

}

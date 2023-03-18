using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void FullScreenTogle()
    {
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
        }
        else
        {
            Screen.fullScreen = true;
        }
    }

    public void ExitSettingsMenu()
    {
        gameObject.SetActive(false);
    }
}

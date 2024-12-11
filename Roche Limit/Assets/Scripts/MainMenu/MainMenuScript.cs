using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}


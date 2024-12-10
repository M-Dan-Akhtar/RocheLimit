using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverScreen : MonoBehaviour
{
    public void RestartButton()
    {

        // Change the scene name based on your scene
        // make sure to add your scene to build settings (File > Build Settings)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Place holder, implement "back to menu" functionality here
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}

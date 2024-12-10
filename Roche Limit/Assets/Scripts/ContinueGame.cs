using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Continue_Game : MonoBehaviour
{
    // Start is called before the first frame update
    public Button continueButton;

    void Start()
    {
    string level = PlayerPrefs.GetString("level");
    if(level == "")
    {
        continueButton.interactable = false;
    }
    }
  public void ContinueGame()
  {
    SceneManager.LoadScene(PlayerPrefs.GetString("level"));
  }
}
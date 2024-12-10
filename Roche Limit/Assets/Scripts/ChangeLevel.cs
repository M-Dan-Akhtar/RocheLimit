using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    public string insertedLevelName;
   public static string finishedLevel; //using this for scene switching (saves the name of the completed level)
    
    void OnTriggerEnter2D(Collider2D winFlag)
    {
        if (winFlag.CompareTag("Player"))
        {
            
           finishedLevel = SceneManager.GetActiveScene().name;
           // holds the name of the level you just beat          
            Debug.Log(finishedLevel);
            SaveSystem.SaveGame();
            SceneManager.LoadScene("WinScreen");
            
        }
    }
       public void NextScene(){
        if(finishedLevel.Equals("SterlingTestScene")){
            Debug.Log("Previous level was SterlingTestScene aka Level 1. So, loading level 2 aka SterlingTestScene2");
            //lvlButtons[1].interactable = true;
            SceneManager.LoadScene("SterlingTestScene2");
        }
        else{
         Debug.Log("ERROR:");
        SceneManager.LoadScene(0);
        //switch to end of game screen I think eventually
        }
       
       }
    // Start is called before the first frame update

    public void SelectScene(){
        SceneManager.LoadScene(insertedLevelName);
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("level");
        SceneManager.LoadScene("SterlingTestScene");
    }
}
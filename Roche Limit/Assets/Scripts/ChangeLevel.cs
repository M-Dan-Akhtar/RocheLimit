using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ChangeLevel : MonoBehaviour
{
    public string insertedLevelName;
    public Text scoreField;
   public static string finishedLevel; //using this for scene switching (saves the name of the completed level)
    
    // void OnTriggerEnter2D(Collider2D winFlag)
    // {
    //     if (winFlag.CompareTag("Player"))
    //     {
            
    //        finishedLevel = SceneManager.GetActiveScene().name;
    //        // holds the name of the level you just beat          
    //         Debug.Log(finishedLevel);
    //         SaveSystem.SaveGame();
    //         SceneManager.LoadScene("WinScreen");
            
    //     }
    // }
      public void Start(){
        if(scoreField != null){
          scoreField.text = "Score(Time): " + TimerController.timerValue.ToString("F2");
        }
      }
        public void Awake(){
          
        }
       public void NextScene(){
        if(finishedLevel.Equals("Level1")){
            Debug.Log("Previously completed level was Level 1. So, loading level 2");
            //lvlButtons[1].interactable = true;
            SceneManager.LoadScene("Level2");
        }
            if(finishedLevel.Equals("Level2")){
            Debug.Log("Previously completed level was Level 2. So, loading level 3");
            //lvlButtons[1].interactable = true;
            SceneManager.LoadScene("Level3");
        }
            if(finishedLevel.Equals("Level3")){
            Debug.Log("Previously completed level was Level 3. So, loading level 4");
            //lvlButtons[1].interactable = true;
            SceneManager.LoadScene("Level4");
        }
       }
    // Start is called before the first frame update

    public void SelectScene(){
        SceneManager.LoadScene(insertedLevelName);
    }
    public void NewGame()
    {
        PlayerPrefs.DeleteKey("level");
        SceneManager.LoadScene("Level1");
    }
}
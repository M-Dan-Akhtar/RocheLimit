using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string insertedLevelName;
    private static string previousLevel; //using this for scene switching (saves the name of previous scene)
 
    void OnTriggerEnter2D(Collider2D winFlag)
    {
        if (winFlag.CompareTag("Player"))
        {
            string currentLevel= SceneManager.GetActiveScene().name;
            previousLevel = currentLevel;// holds the name of the level you just played            
            Debug.Log(previousLevel);
            SceneManager.LoadScene("WinScreen");
            
        }
    }
       public void NextScene(){
        if(previousLevel.Equals("SterlingTestScene")){
            Debug.Log("Previous level was SterlingTestScene aka Level 1. So, loading level 2 aka SterlingTestScene2");
            SceneManager.LoadScene("SterlingTestScene2");
        }
        else{
         Debug.Log("Scene name was empty");
        SceneManager.LoadScene(0);
        //switch to end of game screen I think eventually
        }
       
       }
    // Start is called before the first frame update

    public void SelectScene(){
        SceneManager.LoadScene(insertedLevelName);
    }
       public void changeScene(){
       Debug.Log("Previous Level: " + previousLevel);
       //if level name is null?
       Debug.Log("Inserted Level Name: " + insertedLevelName);
       if(insertedLevelName == "")
       {
        if(previousLevel.Equals("SterlingTestScene")){
            Debug.Log("Previous level was SterlingTestScene aka Level 1. So, loading level 2 aka SterlingTestScene2");
            SceneManager.LoadScene("SterlingTestScene2");
        }
        else{
         Debug.Log("Scene name was empty");
        SceneManager.LoadScene(0);
        //switch to end of game screen I think eventually
        }
       
       }
       else{
        SceneManager.LoadScene(insertedLevelName);
       }
       
    }
}

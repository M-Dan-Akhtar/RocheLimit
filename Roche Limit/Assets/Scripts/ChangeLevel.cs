using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public string insertedLevelName;
    private static string level; //using this for scene switching (saves the name of previous scene)
 
    void OnTriggerEnter2D(Collider2D winFlag)
    {
        if (winFlag.CompareTag("Player"))
        {
            level = SceneManager.GetActiveScene().name;// holds the name of the level you just played            
            Debug.Log(level);
            SceneManager.LoadScene("WinScreen");
            
        }
    }
    // Start is called before the first frame update
       public void changeScene(){
       Debug.Log(level);
       //if level name is null?
       Debug.Log(insertedLevelName);
       if(insertedLevelName == "")
       {
        if(level.Equals("SterlingTestScene")){
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

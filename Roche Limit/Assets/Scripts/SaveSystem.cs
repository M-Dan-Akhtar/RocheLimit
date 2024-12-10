using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.Collections;
using UnityEngine.SceneManagement;

public class SaveSystem : MonoBehaviour
{   
    //Add Player player
    public static string savedLevel = "";
    public static void SaveGame()
    {
         string finishedLevel;
        if(ChangeLevel.finishedLevel == null){
            finishedLevel = "";
        }
        else{
         finishedLevel = ChangeLevel.finishedLevel;
        }
       
        // if(finishedLevel.Equals("")){
        //     savedLevel = "SterlingTestScene";
        // }
        // else (finishedLevel.Equals("SterlingTestScene")){
        //     savedLevel = "SterlingTestScene2";
        // }
        if(finishedLevel.Equals("")){
            savedLevel = "Level1";
        }
        else if(finishedLevel.Equals("Level1")){
            savedLevel = "Level2";
        }
         else if(finishedLevel.Equals("Level2")){
            savedLevel = "Level3";
        }
        else //finishedLevel = Level3
        {
            savedLevel = "Level4";
        }

        PlayerPrefs.SetString("level",savedLevel);
        Debug.Log("Saved Level: "+ savedLevel);
    }
    public void LoadData()
    {
        savedLevel = PlayerPrefs.GetString("level");
        SceneManager.LoadScene(savedLevel);

    }

  
}
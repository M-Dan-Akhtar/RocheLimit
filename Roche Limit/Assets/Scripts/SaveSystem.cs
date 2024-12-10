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
       
        if(finishedLevel.Equals("")){
            savedLevel = "SterlingTestScene";
        }
        else if(finishedLevel.Equals("SterlingTestScene")){
            savedLevel = "SterlingTestScene2";
        }
        else
        {

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
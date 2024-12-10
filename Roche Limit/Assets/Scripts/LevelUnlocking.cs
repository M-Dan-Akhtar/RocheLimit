using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelUnlocking : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
  public Button[] levelButtons;
    void Update()
    {
      
      //change to SaveSystem.nextLevel
    // if(SaveSystem.savedLevel == "SterlingTestScene2"){
    //     levelButtons[1].interactable = true;
    // }
      if(SaveSystem.savedLevel == "Level2"){
        levelButtons[1].interactable = true;
    }
     if(SaveSystem.savedLevel == "Level3"){
        levelButtons[1].interactable = true;
        levelButtons[2].interactable = true;
    }
     if(SaveSystem.savedLevel == "Level4"){
        levelButtons[1].interactable = true;
        levelButtons[2].interactable = true;
        levelButtons[3].interactable = true;
    }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ShareScore : MonoBehaviour
{
    public TMP_InputField usernameText;
    public static string score = "";
    public void PostScore()
    {
      score = TimerController.timerValue.ToString("F2");
      if(usernameText.text != ""){
        string url ="https://lightgray-lyrebird-146622.hostingersite.com/?";
        url += "username=" + usernameText.text + "&score=" + score;
        Application.OpenURL(url);
      }
    }
}

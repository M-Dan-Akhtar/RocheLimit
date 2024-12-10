using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    public float timerValue = 0.0f;
    public float twoStar = 60.0f;
    public float oneStar = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        timerText.GetComponent<Text>().color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        timerValue += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timerValue / 60f);
	    int seconds = Mathf.FloorToInt(timerValue % 60f);
        timerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00");
        
        if (timerValue > twoStar && timerValue < oneStar)
        {
            timerText.GetComponent<Text>().color = Color.yellow;
        }
        else if (timerValue > oneStar)
        {
            timerText.GetComponent<Text>().color = Color.red;
        }
        else
        {
            //timerText.GetComponent<Text>().color = Color.green;
        }
    }
}

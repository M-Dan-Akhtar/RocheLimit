using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform playerTransform;
    void Awake()
    {
       TimerController.timerValue = 0;
       TimerController.toggleTimer();
    }



    // Start is called before the first frame update
    void Start()
    {
      playerTransform = GameObject.Find("Player").transform;
    }




    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
        transform.position = pos;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    private GameObject camera1;
    private GameObject camera2;
    private GameObject player1;
    private GameObject player2;
    private bool isCamera1 = true;

    // Start is called before the first frame update
    void Start()
    {
        camera1 = GameObject.Find("Timeline1 Camera");
        camera2 = GameObject.Find("Timeline2 Camera");
        camera1.SetActive(true);
        camera2.SetActive(false);

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.SetActive(true);
        player2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            if (isCamera1)
            {
                camera1.SetActive(false);
                camera2.SetActive(true);
                player1.SetActive(false);
                player2.SetActive(true);
                isCamera1 = false;
            }
            else
            {
                camera1.SetActive(true);
                camera2.SetActive(false);
                player1.SetActive(true);
                player2.SetActive(false);
                isCamera1 = true;
            }
        }
    }
}

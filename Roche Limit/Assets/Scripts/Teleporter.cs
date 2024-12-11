using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporter : MonoBehaviour
{
    private GameObject player;
    private GameObject camera;
    private Transform alternateStart;

    private Vector3 previousLocation;
    private Vector3 previousFacing;
    private Vector3 previousCamera;

    private GameObject clouds;
    private GameObject dust;
    private bool toggleTimeLineClouds = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        camera = GameObject.Find("Camera");
        alternateStart = GameObject.Find("AlternateTimelineStart").transform;
        clouds = GameObject.Find("Clouds");
        dust = GameObject.Find("Dust");
        toggleClouds();

        previousLocation = new Vector3(alternateStart.position.x, alternateStart.position.y, alternateStart.position.z);
        previousCamera = new Vector3(alternateStart.position.x, camera.transform.position.y + 100.0f, camera.transform.position.z);
        previousFacing = new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c"))
        {
          
            player.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            player.GetComponent<PlayerMovement>().enabled = false;
            StartCoroutine(WaitAndTeleport(1));            

        }
        
    }

    private void toggleClouds(){
      clouds.GetComponent<SpriteRenderer>().enabled = toggleTimeLineClouds;
      dust.GetComponent<SpriteRenderer>().enabled = toggleTimeLineClouds;
      toggleTimeLineClouds = !toggleTimeLineClouds;
    }

    IEnumerator WaitAndTeleport(int s)
    {       
        Vector3 currentLocation = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        Vector3 currentCamera = new Vector3(camera.transform.position.x, camera.transform.position.y, camera.transform.position.z);
        Vector3 currentFacing = new Vector3(player.transform.localScale.x, player.transform.localScale.y, player.transform.localScale.z);

        toggleClouds();
        player.transform.position = previousLocation;
        player.transform.localScale = previousFacing;
        camera.transform.position = previousCamera;

        previousLocation = currentLocation;
        previousCamera = currentCamera;
        previousFacing = currentFacing;

        yield return new WaitForSeconds(s);

        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Animator>().enabled = true;
        player.GetComponent<PlayerMovement>().enabled = true;
    }

}
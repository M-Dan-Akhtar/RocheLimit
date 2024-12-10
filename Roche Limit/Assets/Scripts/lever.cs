using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{   

    public GameObject door;
    [SerializeField]private Color lockedColor = Color.red;
    [SerializeField]private Color unlockedColor = Color.green;
    private bool isPlayerNearby = false;

    private exitDoor doorScript;

    void Start()
    {
      if (door != null){
        doorScript = door.GetComponent<exitDoor>();
      }
    }

    // Update is called once per frame
    void Update()
    {
         if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            doorScript.Unlock();
            SpriteRenderer leverRenderer = GetComponent<SpriteRenderer>();
            leverRenderer.color = unlockedColor; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

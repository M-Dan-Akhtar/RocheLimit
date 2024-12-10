using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class exitDoor : MonoBehaviour
{
    [SerializeField]private Color lockedColor = Color.red;
    [SerializeField]private Color unlockedColor = Color.green;

    private bool isPlayerNearby = false;

    public bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && locked == false)
        {
            ChangeLevel.finishedLevel = SceneManager.GetActiveScene().name;
           // holds the name of the level you just beat
            ChangeLevel.finishedLevel = SceneManager.GetActiveScene().name;
            Debug.Log(ChangeLevel.finishedLevel);
            SaveSystem.SaveGame();
            SceneManager.LoadScene("WinScreen");
            
        }
    }

    public void Unlock()
    {
      if (locked)
      {
        locked = false;
      }

      SpriteRenderer doorRenderer = GetComponent<SpriteRenderer>();
      doorRenderer.color = unlockedColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
            Debug.Log("Player is near the door");      
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

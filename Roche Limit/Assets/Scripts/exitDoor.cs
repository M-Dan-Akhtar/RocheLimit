using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoor : MonoBehaviour
{
    [SerializeField]private Color lockedColor = Color.red;
    [SerializeField]private Color unlockedColor = Color.green;
    public bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
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
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private AudioClip hurtSound;
    public int damage;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            SoundManger.instance.PlaySound(hurtSound);
            collision.gameObject.GetComponent<PlayerHealth>().currentHealth -= damage;    
        }
    }
}

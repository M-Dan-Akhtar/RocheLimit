using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    private bool isDead;

    public HealthBar healthBar;
    public GameManagerScript gameManager;

    [SerializeField] private AudioClip deathSound;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    private void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0 && !isDead)
        {
            SoundManger.instance.PlaySound(deathSound);
            isDead = true;
            gameManager.gameOver();
            //Destroy(gameObject);
        }

    }

}

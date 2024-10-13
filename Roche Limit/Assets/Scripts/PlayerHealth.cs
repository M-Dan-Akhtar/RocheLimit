using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }

    private void Update()
    {
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            // Place lose screen here

            Destroy(gameObject);
        }

    }

}

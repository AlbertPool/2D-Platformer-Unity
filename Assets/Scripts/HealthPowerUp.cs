using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healAmount = 1; // Amount of health the power-up heals
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                Destroy(gameObject); // Destroy the power-up after it is collected
            }
        }
    }
}

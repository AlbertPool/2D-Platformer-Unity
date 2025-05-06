using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] PlayerHealth playerHealth; // Reference to the PlayerHealth script
    float remainingTime = 60f; // Initialize to 1 minute

    private static Timer instance;

    private void Awake()
    {
        // Ensure there is only one instance of the Timer
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy the duplicate Timer object
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            if (remainingTime <= 0)
            {
                remainingTime = 0;
                // Apply damage when the time is up
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(1);
                    // Reset the timer or handle it accordingly
                    ResetTimer();
                }
            }
        }
    }

    private void ResetTimer()
    {
        // Reset the timer to 1 minute or handle it accordingly
        remainingTime = 60f;
    }
}

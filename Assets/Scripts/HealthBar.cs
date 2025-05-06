using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image fillImage;
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        else if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = 0;
        if (playerHealth != null && playerHealth.maxHealth > 0) 
        {
            fillValue = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        }
        slider.value = fillValue;
    }
}

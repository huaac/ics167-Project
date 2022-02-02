using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Added by: Alice Hua
// Health bar for enemy variations

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    // Each enemy can set their max health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    // resets the health to show change
    public void SetHealth(int health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

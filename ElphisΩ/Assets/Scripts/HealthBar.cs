using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour

{
    public Image healthbarImage;

    public PlayerController player;
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

/*
    public void UpdateHealthBar()
    {
        healthbarImage.fillAmount = Mathf.Clamp(player.currHealth / player.maxHealth, 0, 1f);
        //healthbarImage.fillAmount = Mathf.Clamp(player.currHealth, 0, 1f);
    }
    */

}

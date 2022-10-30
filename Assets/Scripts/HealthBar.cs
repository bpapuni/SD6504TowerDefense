using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public GameObject healthBar;
    public Slider slider;

    public void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealthBarCanvas");
        
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        healthBar.SetActive(true);
        System.Threading.Thread.Sleep(3000);
        healthBar.SetActive(false);
        slider.value = health;
    }
}

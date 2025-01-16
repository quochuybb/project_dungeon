using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeHealthBar : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] StatsHandler statsHandler;

    private void Start()
    {
        healthSlider.maxValue = statsHandler.stats.maxHealth;
    }

    public void Update()
    {
        healthSlider.value = statsHandler.CurrentHealth.maxHealth;
    }
}

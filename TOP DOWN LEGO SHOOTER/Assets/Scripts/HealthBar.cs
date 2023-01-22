using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBarMaskSlider;

    public void StartupHealthBarConfig(int maxValue)
    {
        _healthBarMaskSlider.maxValue = maxValue;
        _healthBarMaskSlider.value = maxValue;
    }

    public void SetHealth(int newHealthValue)
    {
        _healthBarMaskSlider.value = newHealthValue;
    }

}

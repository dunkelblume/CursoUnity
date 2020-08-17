using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public Image CharacterPortrait;
    public Image HealthBar;

    public void UpdateHealth(float _currentHealth, float _maxHealth)
    {
        float fillAmount = Mathf.Clamp((_currentHealth / _maxHealth), 0.0f, 1.0f);
        HealthBar.fillAmount = fillAmount;
    }

}

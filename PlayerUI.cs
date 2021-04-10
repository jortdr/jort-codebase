using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{ 
    [Header("Ammo UI")]
    public TMP_Text AmmoText;

    [Header("HealthUI")]
    public TMP_Text HealthText;
    public Slider HealthSlider;


    public void RefreshAmmo(int CurrentLoad, int AmmoCount)
    {
        AmmoText.text = CurrentLoad + "/" + AmmoCount;
    }

    public void RefreshHealth(int Health)
    {
        HealthText.text = Health.ToString();
        HealthSlider.value = Health;
    }
}

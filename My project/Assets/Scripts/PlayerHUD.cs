using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentHealthText;
    [SerializeField] private TextMeshProUGUI currentGunAmmoText;





    public void UpdateHealth(float currentHealth)
    {

        currentHealthText.text = currentHealth.ToString();
    }

    public void UpdateAmmo(int currentGunAmmo)
    {
        currentGunAmmoText.text = currentGunAmmo.ToString();
    }
}

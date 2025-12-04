using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image barImage;

    public void UpdateHealthbar(float maxHealth, float health)
    {
        barImage.fillAmount = health / maxHealth;
    }
}

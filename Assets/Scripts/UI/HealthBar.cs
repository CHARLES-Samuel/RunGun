using UnityEngine;
using UnityEngine.UI;

/**
    Affichage de la barre de vie
*/
public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    // Initialise la valeur max de la barre de vie
    public void setMaxHealthUI(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Mets a jour la barre de vie
    public void setHealthUI(int health)
    {
        slider.value = health;
    }
}

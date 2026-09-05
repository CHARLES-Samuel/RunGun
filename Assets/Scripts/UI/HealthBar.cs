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
    public void SetMaxHealthUI(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Mets a jour la barre de vie
    public void SetHealthUI(int health)
    {
        slider.value = health;
    }
}

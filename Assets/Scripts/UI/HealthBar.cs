using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void setMaxHealthUI(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealthUI(int health)
    {
        slider.value = health;
    }
}

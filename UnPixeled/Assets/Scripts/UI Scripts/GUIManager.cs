using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [SerializeField] public Slider healthBar;
    [SerializeField] public Slider energyBar;
    [SerializeField] public Slider expirienceBar;

    public void HealthBar (float ammount)
    {
        healthBar.value = ammount;
    }

    public void EnergyBar(float ammount)
    {
        energyBar.value = ammount;
    }

    public void ExpirienceBar(float ammount)
    {
        expirienceBar.value = ammount;
    }
}

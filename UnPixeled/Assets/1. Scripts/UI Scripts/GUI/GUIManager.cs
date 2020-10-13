using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    [SerializeField] public Slider healthBar;
    [SerializeField] public Slider energyBar;
    [SerializeField] public Slider expirienceBar;



    // Functions //____________________________________________________________________________________________________________________________________________________________________________
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

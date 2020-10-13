using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using UnityEngine;


public class HealthStats_player : MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    FloatingText floatingText;

    playerController playerController;
    GUIManager GUIManager;
    public TextMesh damageText;

    public float health = 100;
    public float healthRegeneration;
    public float expirience = 0;

    public float energy = 100;
    public float energyUseForDash = 20;
    public float energyRegeneration = 1;

    private void Start()//____________________________________________________________________________________________________________________________________________________________________________
    {
        GUIManager = GameManager.instance.GUIManager.GetComponent<GUIManager>();
        playerController = GameManager.instance.playerController;
        floatingText = GameManager.instance.floatingText.GetComponent<FloatingText>();
    }

    void Update()//____________________________________________________________________________________________________________________________________________________________________________
    {
        GUIManager.HealthBar(health);
        GUIManager.EnergyBar(energy);
        GUIManager.ExpirienceBar(expirience);

        if (health <= 0)
        {
            playerController.GetComponent<playerController>().characterDeath(false);
        }

        regenerateHealth();
        regenerateEnergy();
    }



    // Functions //____________________________________________________________________________________________________________________________________________________________________________

    public void dropStat (int type, float value) //доработать Min Max
    {
        switch (type)
        {
            case 1:
                if (health > 0 && playerController.isDasing == false)
                {
                        health -= value;
                        floatingText.showText(transform, value, 0);
                }
                break;

            case 2:
                if (energy > 0)
                {
                    energy -= energyUseForDash * Time.deltaTime;
                }
                break;
        }
    }

    public void addStat(int type, float value) //доработать Min Max
    {
        switch (type)
        {
            case 1:
                if (health <= 100)
                {
                    health += value;
                }
                break;

            case 2:
                if (energy <= 100)
                {
                    energy += value;
                }
                break;
        }
    }

    void regenerateHealth ()
    {
        if (health <=100)
        {
            health += healthRegeneration * Time.deltaTime;
        }
    }

    void regenerateEnergy()
    {
        if (Input.GetKey(KeyCode.Space) != true && energy <= 100)
        {
            energy += energyRegeneration * Time.deltaTime;
        }
    }
}

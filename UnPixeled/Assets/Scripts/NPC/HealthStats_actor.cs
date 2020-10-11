using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthStats_actor: MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    public float health = 100;

    FloatingText floatingText;
    playerController player;

    private void Start()//____________________________________________________________________________________________________________________________________________________________________________
    {
        player = GameManager.instance.player;
        floatingText = GameManager.instance.floatingText.GetComponent<FloatingText>();
    }

    private void OnTriggerEnter(Collider other)//____________________________________________________________________________________________________________________________________________________________________________
    {
        if (other.tag == "Weapon" && player.defenceState == false)
        {
            healthDamage(25);
        }
    }

    private void Update()//____________________________________________________________________________________________________________________________________________________________________________
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }//kill enemy
    }



    // Functions //____________________________________________________________________________________________________________________________________________________________________________

    void healthDamage (float damage)
    {
        floatingText.showText(transform, damage, 1);

        transform.Translate(0, 0, -2);
        health -= damage;
    }
}

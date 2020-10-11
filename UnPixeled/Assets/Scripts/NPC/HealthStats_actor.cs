using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthStats_actor: MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    public float health = 100;
    public bool dead = false;
    Transform currentPos;

    FloatingText floatingText;
    playerController player;

    private void Start()//____________________________________________________________________________________________________________________________________________________________________________
    {
        player = GameManager.instance.player;
        floatingText = GameManager.instance.floatingText.GetComponent<FloatingText>();
    }

    private void OnTriggerEnter(Collider other)//____________________________________________________________________________________________________________________________________________________________________________
    {

        if (other.tag == "Weapon" && player.defenceState == false && dead == false && health >= 0)
        {
            healthDamage(34);
        }

        if (other.tag == "Projectile" && other.gameObject.GetComponent<Projectile>().defended == true)
        {
            healthDamage(20);
        }
    }

    private void Update()//____________________________________________________________________________________________________________________________________________________________________________
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }



    // Functions //____________________________________________________________________________________________________________________________________________________________________________

    public void healthDamage (float damage)
    {
        floatingText.showText(transform, damage, 1);

        health -= damage;

        switch (GetComponent<EnemyAI_Soul>().ai_Type)
        {
            case EnemyAI_Soul.AI_Type.melee:
                GetComponent<NavMeshAgent>().Move(transform.forward * -5);
                break;
            case EnemyAI_Soul.AI_Type.range:
                break;
        }
    }
}

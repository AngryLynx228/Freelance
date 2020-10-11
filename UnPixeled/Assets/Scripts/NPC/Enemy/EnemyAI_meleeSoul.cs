using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class EnemyAI_meleeSoul : MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    [Header("AI Settings")]
    public float lookRadius = 100.0f;

    [Header("Parameters")]
    public float damage = 1;
    public float attackDelay = 100;

    float lastAttacked = -9999;

    playerController player;
    NavMeshAgent npc;



    void Start()//____________________________________________________________________________________________________________________________________________________________________________
    {
        player = GameManager.instance.player;
        npc = GetComponent<NavMeshAgent>();
    }

    void Update()//____________________________________________________________________________________________________________________________________________________________________________
    {
        ActorActions();
    }



    // Functions //____________________________________________________________________________________________________________________________________________________________________________

    private void ActorActions()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position); // Count distance

        if (distance <= lookRadius) // If actor detect player in look raduis
        {
            ActorMove();
            ActorAttack(distance); // Attacks player when in range with delay
        }
    }

    private void ActorMove()
    {
        npc.SetDestination(player.transform.position);
    }

    private void ActorAttack(float distance)
    {
        if (distance <= npc.stoppingDistance && Time.time > lastAttacked + attackDelay)
        {
            player.GetComponent<HealthStats_player>().dropStat(1, damage);
            transform.Translate(0, 0, 1);
            lastAttacked = Time.time;
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}


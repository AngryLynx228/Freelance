using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class meleeEnemy : MonoBehaviour
{
    public float lookRadius = 100.0f;
    public float damage = 1;

    public float attackDelay = 100;
    float lastAttacked = -9999;

    playerController player;
    NavMeshAgent npc;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
        npc = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= lookRadius)
        {
            npc.SetDestination(player.transform.position);

            if (distance <= npc.stoppingDistance)
            {
                Attack();
            }
        }
    }

    private void Attack()
    { //Call this in OnTriggerStay if the colliding gameObject is the player
        if (Time.time > lastAttacked + attackDelay)
        {
            player.GetComponent<playerStats>().dropStat(1, damage);
            lastAttacked = Time.time;
        }
    }

        void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}


using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class EnemyAI_Soul : MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    [Header("AI Settings")]
    [SerializeField] public float lookRadius;
    public enum AI_Type { melee, range}
    public AI_Type ai_Type;

    [Header("Parameters")]
    [SerializeField] public float damage;
    [SerializeField] public float attackDelay;
    [SerializeField] public GameObject projectile;
    [SerializeField] public Transform pfPojectile;

    float lastAttacked = -9999;

    playerController player;
    NavMeshAgent npc;
    HealthStats_actor hb;



    void Start()//____________________________________________________________________________________________________________________________________________________________________________
    {
        player = GameManager.instance.player;
        npc = GetComponent<NavMeshAgent>();
        hb = GetComponent<HealthStats_actor>();
    }

    void Update()//____________________________________________________________________________________________________________________________________________________________________________
    {
        if (hb.dead == false)
        {
            ActorActions();
        }
        else
        {
            npc.SetDestination(transform.position);
        }
    }



    // Functions //____________________________________________________________________________________________________________________________________________________________________________

    private void ActorActions()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position); // Count distance

        if (distance <= lookRadius) // If actor detect player in look raduis
        {
            ActorMove(distance);
            ActorAttack(distance); // Attacks player when in range with delay
        }
    }

    private void ActorMove(float distance)
    {
        switch (ai_Type)
        {
            case AI_Type.melee:

                npc.SetDestination(player.transform.position);

                break;



            case AI_Type.range:

                Transform startTransform = transform;
                transform.rotation = Quaternion.LookRotation(transform.position - player.transform.position);
                Vector3 runTo = transform.position + transform.forward * distance;
                
                NavMeshHit hit;
                NavMesh.SamplePosition(runTo, out hit, 5, 1 << NavMesh.GetAreaFromName("Walkable"));

                transform.position = startTransform.position;
                transform.rotation = startTransform.rotation;

                npc.SetDestination(hit.position);

                break;


        }
    }

    private void ActorAttack(float distance)
    {
        if (Time.time > lastAttacked + attackDelay)
        {
            switch (ai_Type)
            {
                case AI_Type.melee:
                    if (distance <= npc.stoppingDistance)
                    {
                        player.GetComponent<HealthStats_player>().dropStat(1, damage);
                        lastAttacked = Time.time;
                    }

                    break;



                case AI_Type.range:

                    if (distance <= lookRadius)
                    {
                        GameObject bullet = Instantiate(projectile, pfPojectile.transform.position, pfPojectile.transform.rotation) as GameObject;
                        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * -1500);

                        lastAttacked = Time.time;
                    }

                    break;


            }
        }

    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}


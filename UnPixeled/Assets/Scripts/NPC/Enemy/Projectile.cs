using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool defended = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                collision.gameObject.GetComponent<HealthStats_player>().dropStat(1, 20);
                Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * -2500);
            defended = true;
        }
    }
}


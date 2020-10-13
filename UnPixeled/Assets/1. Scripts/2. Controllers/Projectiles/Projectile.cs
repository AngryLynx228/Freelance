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
            if (GameManager.instance.player.GetComponent<playerController>().defenceState != true)
            {
                GetComponent<Rigidbody>().AddForce(transform.forward * -3000);
                defended = true;
            }
            else
            {
                GetComponent<Rigidbody>().AddForce(transform.right * -3000);
                defended = false;
            }
        }
    }
}


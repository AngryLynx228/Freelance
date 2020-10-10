using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health = 100;
    public TextMesh damageText;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            healthDamage(20);
        }
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void healthDamage (float damage)
    {
        this.transform.Translate(0, 0, -2);
        showFloatingText(damage);
        health -= damage;
    }

    void showFloatingText (float damage)
    {
        var go = Instantiate(damageText, new Vector3(transform.position.x + Random.Range(0,5), transform.position.y + Random.Range(0, 5), transform.position.z + Random.Range(0, 5)), Quaternion.Euler(60, 45, 0));
        go.GetComponent<TextMesh>().text = damage.ToString();
    }
}

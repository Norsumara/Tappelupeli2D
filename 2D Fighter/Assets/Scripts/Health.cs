using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    private float hitTimer = 0.15f;
    public bool isHit = false;
    public bool isDummy;

    Rigidbody2D rb;
    PlayerMove pm;
    Fighting fs;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMove>();
        fs = GetComponent<Fighting>();

        health = maxHealth;
    }

    void FixedUpdate()
    {
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //kuole
    }

    public void TakeDamage(float damage)
    {
        if(!isHit)
        {
            if(fs.blockCheck)
            {
                health -= damage/2;
            }
            else
            {
                health -= damage;
                StartCoroutine(kb());
            }
            Debug.Log("Health: " + health);
        }
    }

    IEnumerator kb()
    {
        isHit = true;
        rb.velocity = new Vector2(pm.facing * - 2.5f, 2.5f);

        yield return new WaitForSeconds(hitTimer);

        isHit = false;
    }
}

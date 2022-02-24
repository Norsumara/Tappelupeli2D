using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health = 100f;
    private float hitTimer = 0.15f;
    public bool isHit = false;

    Rigidbody2D rb;
    PlayerMove pm;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMove>();

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
            health -= damage;
            StartCoroutine(kb());
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

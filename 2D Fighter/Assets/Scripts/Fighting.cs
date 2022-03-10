using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighting : MonoBehaviour
{
    public float punchDamage = 2f;
    public float kickDamage = 3.5f;
    public bool blockCheck = false;
    public Transform punchCheck;
    public Transform kickCheck;
    public float range = 1.7f;
    public LayerMask enemyLayer;
    public float cooldown = 0.25f;

    private float cooldownTimer;
    private bool attacking = false;
    private bool hit = false;
    private int chooser;

    Health healthScript;

    void Start()
    {
        healthScript = GetComponent<Health>();
    }

    void Update()
    {
        
    }

    void Attack(Transform check, float damage)
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(check.position,range,enemyLayer);
        if(enemyHit != null)
        {
            foreach(Collider2D enemy in enemyHit)
            {
                if(enemy.gameObject != this.gameObject)
                {
                    enemy.GetComponent<Health>().TakeDamage(damage);
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punchCheck.position,range);
        Gizmos.DrawWireSphere(kickCheck.position,range);
    }
}

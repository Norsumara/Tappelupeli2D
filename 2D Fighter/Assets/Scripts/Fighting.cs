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
    public float BlockCooldown = 1f;

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

        if(healthScript.isHit)
        {
            return;
        }

        if(!blockCheck && !attacking && cooldownTimer <= 0)
        {
            if(healthScript.isDummy)
            {
                return;
            }

            if(Input.GetButtonDown("Fire1"))
            {
                Punch();
                Debug.Log("eee");
            }

            if(Input.GetButtonDown("Fire2"))
            {
                Kick();
            }
        }

        if(Input.GetButtonDown("Fire3"))
        {
            if(healthScript.isDummy)
            {
                return;
            }
            Block();
        }

        if(Input.GetButtonUp("Fire3"))
        {
            if(healthScript.isDummy)
            {
                return;
            }
            BlockEnd();
        }

        if(attacking)
        {
            if(cooldownTimer < 0)
            {
                cooldownTimer -= Time.deltaTime;
            }else
            {
                attacking = false;
            }
        }

    }

    void Attack(Transform check, float damage)
    {
        Collider2D[] enemyHit = Physics2D.OverlapCircleAll(check.position,range,enemyLayer);
        if(enemyHit != null)
        {
            foreach(Collider2D enemy in enemyHit)
            {
                if(hit == false)
                {
                    if(enemy.gameObject != this.gameObject)
                    {
                        Debug.Log("Take Damage");
                        enemy.GetComponent<Health>().TakeDamage(damage);
                        hit = true;
                    }   
                }   
            }
            hit = false;
        }
        attacking = true;
        cooldownTimer = cooldown;
    }

    private void Punch()
    {
        //Animation
        Attack(punchCheck, punchDamage);
        Debug.Log("Lyö");
    }

    private void Kick()
    {
        //Animation
        Attack(kickCheck, kickDamage);
        Debug.Log("Lyö");
    }

    private void BlockEnd()
    {
        blockCheck = false;

    }

    private void Block()
    {
        blockCheck = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punchCheck.position,range);
        Gizmos.DrawWireSphere(kickCheck.position,range);
    }
}
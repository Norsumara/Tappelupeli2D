using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 7.5f;
    public float JumpForce = 7.5f;

    Rigidbody2D rb;
    CircleCollider2D cc;
    Health hs;
    Animator an;

    private float horMovement = 0f;
    public int facing = 1;
    public LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        hs = GetComponent<Health>();
        an = GetComponent<Animator>();
    }

    void Update()
    {
        horMovement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && cc.IsTouchingLayers(layerMask))
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            an.SetTrigger("Jump");
        }
        
        if(cc.IsTouchingLayers(layerMask))
        {
            an.SetBool("IsTouchingGround", true);
        }
        else{
            an.SetBool("IsTouchingGround", false);
        }
    }

    void FixedUpdate()
    {
        if(!hs.isHit)
        {

            rb.velocity = new Vector2(horMovement * Speed, rb.velocity.y);
            an.SetFloat("Speed",Mathf.Abs(horMovement));
        }
    }
}

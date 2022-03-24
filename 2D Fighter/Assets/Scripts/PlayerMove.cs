using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 7.5f;
    public float JumpForce = 7.5f;

    Rigidbody2D rb;
    CircleCollider2D cc;
    Health hs;

    private float horMovement = 0f;
    public int facing = 1;
    public LayerMask layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        hs = GetComponent<Health>();
    }

    void Update()
    {
        horMovement = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && cc.IsTouchingLayers(layerMask))
        {
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        if(!hs.isHit)
        {
            rb.velocity = new Vector2(horMovement * Speed, rb.velocity.y);
        }
    }
}

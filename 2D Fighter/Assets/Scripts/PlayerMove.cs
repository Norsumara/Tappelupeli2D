using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float Speed = 7.5f;
    public float Jump = 7.5f;

    Rigidbody2D rb;
    CircleCollider2D cc;

    private float horMovement = 0f;
    public int facing = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        horMovement = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horMovement * Speed, rb.velocity.y);
    }
}

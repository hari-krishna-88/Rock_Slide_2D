using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Animator naimatior;
    private Rigidbody2D rb;


    private void Start()
    {
        naimatior = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            naimatior.SetBool("isRunning", true);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            naimatior.SetBool("isRunning", false);
            rb.velocity = Vector2.zero;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Actualiza los parámetros del Animator
        animator.SetFloat("MoveX", movement.x);
        animator.SetFloat("MoveY", movement.y);
    }

    void FixedUpdate()
    {
        // Movimiento
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
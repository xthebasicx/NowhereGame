using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator animator;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 dashDirection;
    private float dashSpeed = 30f;
    private float dashDuration = 0.2f;
    private float dashCooldown = 0.5f;
    private bool isDashing;
    private float dashTimeLeft;
    private float lastDashTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            OnInput();
        }
    }
    void FixedUpdate()
    {
        if (!PauseMenu.GameIsPaused)
        {
            OnPlayerMove();
        }
    }
    private void OnInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(movement.x, movement.y).normalized;
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && Time.time > lastDashTime + dashCooldown)
        {
            Dash();
        }
    }
    private void OnPlayerMove()
    {
        if (isDashing)
        {
            rb.velocity = dashDirection * dashSpeed;
            dashTimeLeft -= Time.fixedDeltaTime;
            if (dashTimeLeft <= 0)
            {
                isDashing = false;
                lastDashTime = Time.time;
            }
        }
        else
        {
            float speed = movement.magnitude * moveSpeed;
            rb.velocity = movement * speed;
            animator.SetFloat("Speed", speed);
        }
    }
    private void Dash()
    {
        isDashing = true;
        dashDirection = movement;
        dashTimeLeft = dashDuration;
        animator.SetTrigger("Dash");
    }

}

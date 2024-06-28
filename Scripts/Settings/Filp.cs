using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private bool facingRight = true;
    public Rigidbody2D rb;
    private bool isColliding = false;
    public float flipThreshold = 0.1f; 

    void Update()
    {
        if (!isColliding)
        {
            _Flip();
        }
    }

    private void _Flip()
    {
        float velocityX = rb.velocity.x;

        if (velocityX > flipThreshold && !facingRight)
        {
            FlipCharacter();
        }
        else if (velocityX < -flipThreshold && facingRight)
        {
            FlipCharacter();
        }
    }

    private void FlipCharacter()
    {
        facingRight = !facingRight;

        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isColliding = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isColliding = false;
    }
}

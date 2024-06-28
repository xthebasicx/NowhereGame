using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float knockbackStrength = 10f;
    public float knockbackDuration = 0.2f;

    public void ApplyKnockback(Rigidbody2D enemyRigidbody, Vector2 direction)
    {
        StartCoroutine(DoKnockback(enemyRigidbody, direction));
    }

    private IEnumerator DoKnockback(Rigidbody2D enemyRigidbody, Vector2 direction)
    {
        float timer = 0f;
        while (timer < knockbackDuration)
        {
            if (enemyRigidbody != null)
            {
                enemyRigidbody.velocity = direction * knockbackStrength;
            }
            timer += Time.deltaTime;
            yield return null;
        }
        if (enemyRigidbody != null)
        {
            enemyRigidbody.velocity = Vector2.zero;
        }
    }
}

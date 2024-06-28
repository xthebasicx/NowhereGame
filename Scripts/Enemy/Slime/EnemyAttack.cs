using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage = 1f;
    public float attackRadius = 1f;
    private float nextAttackTime = 0f;
    public float attackRate = 2f;

    private void Update()
    {
        if (!PauseMenu.GameIsPaused && Time.time >= nextAttackTime)
        {
            AttackIfPlayerInRange();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    public void AttackIfPlayerInRange()
    {
        Vector2 enemyPosition = transform.position;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(enemyPosition, attackRadius);

        foreach (Collider2D col in hitColliders)
        {
            if (col.CompareTag("Player"))
            {
                col.GetComponent<Health>().TakeDamage(damage);
                return;
            }
        }
    }
}

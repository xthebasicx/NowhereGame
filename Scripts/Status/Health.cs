using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float MaxHP;
    public float CurrentHP;
    public HealthBar healthBar;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Color flashColor = Color.red;
    void Start()
    {
        CurrentHP = MaxHP;
        healthBar.SetMaxHealth(MaxHP);
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(float damage)
    {
        CurrentHP -= damage;
        healthBar.SetHealth(CurrentHP);

        if (CurrentHP <= 0)
        {
            Die();
        }
        spriteRenderer.color = flashColor;
        Invoke("ResetColor", 0.1f);
    }
    private void ResetColor()
    {
        spriteRenderer.color = originalColor;
    }
    protected abstract void Die();
}

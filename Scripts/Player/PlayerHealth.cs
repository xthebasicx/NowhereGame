using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    private Animator playerAnimator;
    private Collider2D playerCollider;
    private void Awake()
    {
        playerAnimator = GameObject.Find("PlayerCharecter").GetComponent<Animator>();
        playerCollider = GetComponent<Collider2D>();
    }
    protected override void Die()
    {
        playerCollider.enabled = false;
        playerAnimator.SetBool("Dead", true);
        Invoke("AfterDie", 1f);
    }
    public void HealToMax()
    {
        CurrentHP = MaxHP;
        healthBar.SetHealth(CurrentHP);
    }
    public void SetHealth(float currentHP)
    {
        CurrentHP = currentHP;
        healthBar.SetHealth(currentHP);
    }
    void AfterDie()
    {
        playerCollider.enabled = true;
        SceneManager.LoadScene("Scenes/Game");
        HealToMax();
        playerAnimator.SetBool("Dead", false);
        transform.position = Vector3.zero;
    }
}

using UnityEngine;

public class SkeletonState : MonoBehaviour
{
    private enum State
    {
        Walk,
        Chase,
        Attack
    }
    private State currentState;
    private GameObject playerTarget;
    private Vector2 direction;
    public Rigidbody2D rb;
    public Transform attackPoint;
    public Animator animator;

    private float distance;
    private float randomTimer;
    private float nextAttackTime;
    private int attackCounter;
    public float DistanceBetween;
    public float WalkMoveSpeed;
    public float ChaseMoveSpeed;
    public float Damage;
    public float attackRate;
    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        currentState = State.Walk;
    }
    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            ChangeState();
            switch (currentState)
            {
                case State.Walk:
                    OnWalk();
                    break;
                case State.Chase:
                    OnChase();
                    break;
                case State.Attack:
                    if (Time.time >= nextAttackTime)
                    {
                        OnAttack();
                        nextAttackTime = Time.time + 1f / attackRate;
                    }
                    break;
            }
        }
    }
    private void ChangeState()
    {
        if (CheckAttack())
        {
            currentState = State.Attack;
        }
        else if (CheckPlayerInRange())
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Walk;
        }
    }
    private bool CheckPlayerInRange()
    {
        distance = Vector2.Distance(this.transform.position, playerTarget.transform.position);
        if (distance < DistanceBetween)
        {
            return true;
        }
        else return false;
    }
    private bool CheckAttack()
    {

        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, 2f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
    private void OnWalk()
    {
        animator.SetFloat("Speed", WalkMoveSpeed);
        randomTimer -= Time.deltaTime;
        if (randomTimer <= 0)
        {

            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            randomTimer = Random.Range(0,4);
        }
        rb.velocity = direction * WalkMoveSpeed;
    }
    private void OnChase()
    {
        animator.SetFloat("Speed", ChaseMoveSpeed);
        direction = playerTarget.transform.position - this.transform.position;
        direction.Normalize();
        rb.velocity = direction * ChaseMoveSpeed;
    }
    private void OnAttack()
    {
        if (attackCounter == 0)
        {
            animator.SetTrigger("Attack");
        }

        rb.velocity = Vector2.zero;
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, 2f);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                hit.GetComponent<Health>().TakeDamage(Damage);
            }
        }
        attackCounter++;
        if (attackCounter >= 2)
        {
            attackCounter = 0;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, 2f);
    }

}

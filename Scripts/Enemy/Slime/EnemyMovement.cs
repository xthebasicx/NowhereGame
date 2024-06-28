using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float distanceBetween;
    private float distance;
    public Animator animator;
    public float idleMoveSpeed;
    public float idleChangeDirectionTime = 2f;
    private Vector2 idleDirection;
    private float idleTimer;
    private Transform target;
    private Rigidbody2D rb;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        rb = GetComponent<Rigidbody2D>();
        idleTimer = idleChangeDirectionTime;
        idleDirection = GetRandomDirection();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);
        Vector2 direction = target.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            rb.velocity = direction * MoveSpeed;
            animator.SetBool("HaveTarget", true);
        }
        else
        {
            animator.SetBool("HaveTarget", false);
            idleTimer -= Time.deltaTime;
            if (idleTimer <= 0)
            {
                idleDirection = GetRandomDirection();
                idleTimer = idleChangeDirectionTime;
            }

            rb.velocity = idleDirection * idleMoveSpeed;
        }
    }

    Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}

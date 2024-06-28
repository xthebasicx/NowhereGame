using UnityEngine;

public class BossState : MonoBehaviour
{
    public static bool Boss = true;
    private GameObject player;
    private Vector2 direction;
    public Rigidbody2D rb;
    public Transform[] Teleport;
    private bool facingRight = true;
    private float distance;
    private float timeElapsed;
    private int currentIndex;
    public float MoveSpeed;
    public float DistanceBetween;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (!PauseMenu.GameIsPaused)
        {
            ChackFilp();
            Movement();

        }
    }

    private bool CheckPlayerInRange()
    {
        distance = Vector2.Distance(this.transform.position, player.transform.position);
        if (distance < DistanceBetween)
        {
            return true;
        }
        else return false;
    }
    private void Movement()
    {

        if (CheckPlayerInRange())
        {
            direction = this.transform.position - player.transform.position;
            direction.Normalize();
            rb.velocity = direction * MoveSpeed;
            timeElapsed += Time.deltaTime;

        if (timeElapsed >= 8.0f)
        {
            if (Teleport.Length > 0)
            {
                Transform target = Teleport[currentIndex];
                transform.position = target.position;

                currentIndex = (currentIndex + 1) % Teleport.Length;
            }
            timeElapsed = 0.0f;
        }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
    private void ChackFilp()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            if (direction.x < 0 && !facingRight)
            {
                Flip();
            }
            else if (direction.x > 0 && facingRight)
            {
                Flip();
            }
        }
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

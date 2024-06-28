using UnityEngine;

public class MiniBoss2Attack : MonoBehaviour
{
    public GameObject projectilePrefab;
    private GameObject player;
    public float shootInterval = 2f;
    public float projectileSpeed = 10f;
    private float shootTimer;
    private Vector2 direction;
    public Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            animator.SetTrigger("Attack");
            Invoke("Shoot",0.5f);
            shootTimer = shootInterval;
        }
    }
    void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, this.transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        direction = player.transform.position - this.transform.position;
        direction.Normalize();
        rb.velocity = direction * projectileSpeed;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 180));

        Destroy(projectile, 3f);
    }
}

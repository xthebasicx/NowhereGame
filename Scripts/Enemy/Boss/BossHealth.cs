public class BossHealth : Health
{
    protected override void Die()
    {
        Destroy(gameObject);
    }

}

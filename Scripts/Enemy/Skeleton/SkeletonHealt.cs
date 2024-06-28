public class SkeletonHealth : Health
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}

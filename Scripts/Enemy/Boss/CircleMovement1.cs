using UnityEngine;

public class CircleMovement1 : MonoBehaviour
{
    public Transform Target;
    public float radius = 5f;
    public float speed = 2f;

    private float angle = 180f;

    void Update()
    {
        float x = Mathf.Cos(angle *Mathf.Deg2Rad) * radius;
        float y = Mathf.Sin(angle *Mathf.Deg2Rad) * radius;

        transform.position = Target.position + new Vector3(x, y, 0);
        angle += speed * Time.deltaTime;

        if (angle >= 360f)
        {
            angle -= 360f;
        }
    }
}

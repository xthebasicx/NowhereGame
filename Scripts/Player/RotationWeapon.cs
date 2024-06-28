using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    [SerializeField] private Transform weapon;
    [SerializeField] private float weapondistance = 1.5f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        weapon.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg));

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector3(weapondistance, 0, 0);
    }
}

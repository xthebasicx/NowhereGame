using UnityEngine;

public class VoidFireBall : MonoBehaviour
{
    
    private GameObject player;
    public float Damage;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject == player){
            collider.GetComponent<Health>().TakeDamage(Damage);
        }
    }
}

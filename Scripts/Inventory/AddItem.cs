using UnityEngine;

public class AddItem : MonoBehaviour
{
    private Inventory inventory;
    private Item item;
    private bool canInteract = false;
    void Start()
    {
        inventory = GameObject.Find("InventorySystem").GetComponent<Inventory>();
        item = this.GetComponent<Item>();
    }

    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inventory.AddItem(item);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = true;
            Debug.Log("enter");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            canInteract = false;
            Debug.Log("exit");
        }
    }
}

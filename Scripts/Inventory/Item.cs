using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Inventory inventory;
    public Sprite Icon;
    public string ItemName;
    public string ItemDetail;
    public int ItemID { get; private set; }
    private static int nextID = 0;
    public Guid id = Guid.NewGuid();

    void Start()
    {
        inventory = GameObject.Find("InventorySystem").GetComponent<Inventory>();
        ItemID = nextID++;
    }

    public virtual void Use()
    {
        Debug.Log("Using " + ItemName);
    }
}

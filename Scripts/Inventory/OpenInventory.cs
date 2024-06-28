using UnityEngine;

public class OpenInventory : MonoBehaviour
{
    public GameObject InventoryUI;
    private bool open = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (open)
            {
                InventoryUI.SetActive(false);
                open = false;
            }
            else
            {
                InventoryUI.SetActive(true);
                open = true;
            }
        }
    }
}

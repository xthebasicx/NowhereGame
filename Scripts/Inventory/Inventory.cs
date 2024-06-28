using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public GameObject itemSlotPrefab;
    public Transform itemSlotContainer;
    private int maxSlots = 20;

    public void AddItem(Item item)
    {
        if (items.Count >= maxSlots)
        {
            Debug.Log("Inventory is full!");
            return;
        }

        items.Add(item);
        GameObject itemSlot = Instantiate(itemSlotPrefab, itemSlotContainer);
        Transform icon = itemSlot.transform.Find("Icon");
        icon.GetComponent<Image>().sprite = item.Icon;
        itemSlot.name = item.ItemID.ToString();
        Button itemButton = itemSlot.GetComponent<Button>();
        itemButton.onClick.AddListener(() => ShowDetail(item));
    }
    public void RemoveItemByID(int itemID)
    {
        Item itemToRemove = items.Find(item => item.ItemID == itemID);
        if (itemToRemove != null)
        {
            RemoveItem(itemToRemove);
        }
    }
    private void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            foreach (Transform child in itemSlotContainer)
            {
                if (child.gameObject)
                {
                    Destroy(child.gameObject);
                    break;
                }
            }
        }
    }
    private void ShowDetail(Item item)
    {
        GameObject ShowItemDetail = GameObject.Find("ShowItemDetail");

        Transform ItemIcon = ShowItemDetail.transform.Find("Icon");
        Transform ShowIcon = ItemIcon.transform.Find("ItemIcon");

        Image ShowIconImage = ShowIcon.GetComponent<Image>();

        ShowIconImage.enabled = true;
        ShowIconImage.sprite = item.Icon;


        Transform Detail = ShowItemDetail.transform.Find("Detail");

        Transform ItemName = Detail.transform.Find("ItemName");
        Transform ItemDetail = Detail.transform.Find("ItemDetail");

        TextMeshProUGUI TextItemName = ItemName.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI TextItemDetail = ItemDetail.GetComponent<TextMeshProUGUI>();

        TextItemName.text = item.ItemName;
        TextItemDetail.text = item.ItemDetail;


    }

}

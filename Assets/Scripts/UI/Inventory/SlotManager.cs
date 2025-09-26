using System;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public ItemInformation currentItemInfo;
    public GameObject itemPrefab;

    public bool isEmpty = true;

    public void SetCurrentItem(ItemInformation newItem)
    {
        if (currentItemInfo == null)
        {
            isEmpty = true;
        }
        currentItemInfo = newItem;
        isEmpty = false;
        if (transform.childCount > 1)
            Destroy(transform.GetChild(1).gameObject);

        // spawn new item prefab as child of this slot
        GameObject itemUI = Instantiate(itemPrefab, transform);
        itemUI.GetComponent<Image>().sprite = newItem.itemImage;

        // reset position to center
        RectTransform rt = itemUI.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero;
    }

    public void RemoveItem()
    {
        currentItemInfo = null;
    }
}

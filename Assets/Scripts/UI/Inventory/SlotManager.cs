using System;
using UnityEngine;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public ItemInformation currentItemInfo;
    public GameObject itemPrefab;
    [SerializeField] ImageSlot imageSlot;
    public bool isEmpty = true;

    private void Update() 
    {
        //if there is an item
        if(currentItemInfo != null && imageSlot != null && currentItemInfo.itemName == "Coin")
        {
            //display the count
            transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(1).gameObject.SetActive(false);
        }

    }

    public void SetCurrentItem(ItemInformation newItem)
    {
        if (currentItemInfo == null)
        {
            isEmpty = true;
        }
        currentItemInfo = newItem;
        isEmpty = false;
        if (transform.childCount > 2)
            Destroy(transform.GetChild(2).gameObject);

        // spawn new item prefab as child of this slot
        GameObject itemUI = Instantiate(itemPrefab, transform);
        itemUI.GetComponent<Image>().sprite = newItem.itemImage;

        //Set the opacity of the image to 0.5
        Color c = itemUI.GetComponent<Image>().color;
        c.a = 0.5f;
        itemUI.GetComponent<Image>().color = c;

        // reset position to center
        RectTransform rt = itemUI.GetComponent<RectTransform>();
        rt.anchoredPosition = Vector2.zero - new Vector2(0 , 10f);
    }

    public void RemoveItem()
    {
        currentItemInfo = null;
    }

    public string GetItemInfo()
    {
        return currentItemInfo.itemName;
    }
}

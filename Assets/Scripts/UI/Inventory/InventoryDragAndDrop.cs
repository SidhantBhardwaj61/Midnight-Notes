using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; //Save Original parent
        transform.SetParent(transform.root); //Above other canvas'
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; //transaparent when dragging
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position; //Follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; //Enables raycasts
        canvasGroup.alpha = 1f; //No longer transparent

        ImageSlot dropSlot = eventData.pointerEnter?.GetComponent<ImageSlot>(); //Slot where item dropped
        if(dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if (dropItem != null)
            {
                dropSlot = dropItem.GetComponentInParent<ImageSlot>();
            }
        }
        ImageSlot originalSlot = originalParent.GetComponent<ImageSlot>();

        if(dropSlot != null)
        {
            //swap item information
            SlotManager dropSlotManager = dropSlot.GetComponent<SlotManager>();
            SlotManager originalSlotManager = originalSlot.GetComponent<SlotManager>();

            //Is a slot under drop point
            if (dropSlot.currentItem != null)
            {
                //if the slot has an item too then swap both of them
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

                // Swap item data
                ItemInformation tempInfo = dropSlotManager.currentItemInfo;
                dropSlotManager.currentItemInfo = originalSlotManager.currentItemInfo;
                originalSlotManager.currentItemInfo = tempInfo;
            }
            else
            {
                dropSlotManager.currentItemInfo = originalSlotManager.currentItemInfo;
                originalSlotManager.currentItemInfo = null;
                originalSlot.currentItem = null;
            }

            //Move item into drop slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else
        {
            //No slot under drop point
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //Center
    }
}

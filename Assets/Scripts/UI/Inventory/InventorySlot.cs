using System.Collections.Generic;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] List<Transform> inventorySlots;

    int wantedSlot = -1;
    bool isSlotAlreadySelected;

    void Update()
    {
        SelectSlot();
        if (wantedSlot != -1)
        {
            if (isSlotAlreadySelected == true)
            {
                foreach (Transform slot in inventorySlots)
                {
                    slot.GetChild(0).gameObject.SetActive(false);
                    isSlotAlreadySelected = false;
                }
            }

            inventorySlots[wantedSlot].GetChild(0).gameObject.SetActive(true);
            isSlotAlreadySelected = true;       
        }
    }

    void SelectSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            wantedSlot = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            wantedSlot = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            wantedSlot = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            wantedSlot = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            wantedSlot = 4;
        }

    }
}

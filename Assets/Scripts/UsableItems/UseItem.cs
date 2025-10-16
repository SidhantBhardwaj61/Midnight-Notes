using UnityEngine;

public class UseItem : MonoBehaviour
{
    [SerializeField] SlotSelection selectedSlot;
    [SerializeField] CoinSpawner coinSpawner;
    void Update()
    {
        //if we press space while an item is selected
        if (Input.GetKeyDown(KeyCode.Space) && selectedSlot.isSlotAlreadySelected)
        {
            // check if that item is usable
            if (selectedSlot.inventorySlots[selectedSlot.wantedSlot].GetComponent<SlotManager>().GetItemInfo() == "Coin")
            {
                // use that item
                coinSpawner.SpawnCross();
            }
        }
    }
}

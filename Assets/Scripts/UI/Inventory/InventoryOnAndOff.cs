using UnityEngine;

public class InventoryOnAndOff : MonoBehaviour
{
    [SerializeField] GameObject inventoryUI;

    public void TurnOnInventory()
    {
        inventoryUI.SetActive(true);
    }

    public void TurnOffInventory()
    {
        inventoryUI.SetActive(false);
    }
    
}

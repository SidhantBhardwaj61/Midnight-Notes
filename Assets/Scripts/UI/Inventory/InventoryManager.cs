using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance { get; private set; }
    public SlotManager[] slots;
    [SerializeField] public static bool hasKey = false;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public bool SetItem(ItemInformation item)
    {
        foreach (SlotManager slot in slots)
        {
            if (slot.isEmpty)
            {
                slot.SetCurrentItem(item);
                return true;
            }

        }
        return false;
    }
}

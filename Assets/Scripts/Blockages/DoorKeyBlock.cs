using System.Diagnostics;
using UnityEngine;

public class DoorKeyBlock : MonoBehaviour
{
    [SerializeField] GameObject teleport;

    void Update()
    {
        if(InventoryManager.hasKey == true)
        {
            teleport.SetActive(true);
            Destroy(gameObject);
        }
    }
}

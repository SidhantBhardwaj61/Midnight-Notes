
using UnityEngine;

[CreateAssetMenu(fileName = "new item info", menuName = "Item Information")]
public class ItemInformation : ScriptableObject
{
    public GameObject itemPrefab;
    public string itemName;
    public Sprite itemImage;
    public bool canBePicked;
    public string type;
}

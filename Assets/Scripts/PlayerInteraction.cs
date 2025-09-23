using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool canInteract;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            canInteract = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            canInteract = false;
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKey(KeyCode.E))
            {
                Debug.Log("Interacting");
            }
    }
}

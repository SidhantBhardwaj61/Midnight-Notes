
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool canInteract;
    private InteractingObject interactInfo;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            canInteract = true;
            interactInfo = collision.GetComponent<InteractingObject>();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            canInteract = false;
            interactInfo = null;
        }
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
            {
                interactInfo.Interact();
            }
    }
}

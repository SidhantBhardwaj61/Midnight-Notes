
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject passcodeUI;
    private bool canInteract;
    public static bool isClassroom = false;
    private InteractingObject interactInfo;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            canInteract = true;
            interactInfo = collision.GetComponent<InteractingObject>();
        }

        if (collision.tag == "ProhibitedArea")
        {
            interactInfo = collision.GetComponent<InteractingObject>();
            interactInfo.Interact();
        }

        if (collision.tag == "ClassroomGate")
        {
            isClassroom = true;
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            canInteract = false;
            interactInfo = null;
        }
        
        if (collision.tag == "ProhibitedArea")
        {
            interactInfo = null;
        }
            
    }

    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
            {
                interactInfo.Interact();
            }

        if(isClassroom && Input.GetKeyDown(KeyCode.E))
        {
            passcodeUI.SetActive(true);
            PlayerMovement.isPlayerWalkable = false;
        }
    }
}

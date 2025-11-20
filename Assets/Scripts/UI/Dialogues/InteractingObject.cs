using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class InteractingObject : MonoBehaviour
{
    public InteractableDialogue dialogueData;
    private DialogueController dialogueController;
    private int dialogueIndex;
    private bool isTyping, isDialogueActive;
    [SerializeField] Animator playerAnimator;
    [SerializeField] AudioSource obtainedSFX;

    void Start()
    {
        dialogueController = DialogueController.instance;
    }

    public bool CanInteract()
    {
        return !isDialogueActive;
    }

    public void Interact()
    {
        // if no dialogue text remains or can't interact
        if (dialogueData == null)
        {
            return;
        }
        if (isDialogueActive)
        {
            NextLine();  // pressing E again skips to next dialogue
        }
        else
        {
            StartDialogue(); // start the dialogue if the function is called for the first time
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;  // get all required information and start showing dialogue
        PlayerMovement.isPlayerWalkable = false;
        playerAnimator.SetFloat("Speed", 0);
        dialogueIndex = 0;
        dialogueController.ShowDialogueUI(true);

        ShowCurrentLine();
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueController.SetDialogueText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            //show the dialogue in animation
            dialogueController.SetDialogueText(dialogueController.dialogueText.text += letter);
            yield return new WaitForSeconds(dialogueData.typingSpeed);
        }

        isTyping = false;

        // if the dialogue index is less than the total number of bools and the auto progress for that index is true
        if (dialogueData.autoProgressLines.Length > dialogueIndex && dialogueData.autoProgressLines[dialogueIndex])
        {
            //display next line after some time if dialogue has ended
            yield return new WaitForSeconds(dialogueData.autoProgressDelay);
            NextLine();
        }
    }

    void NextLine()
    {
        if (isTyping)  // if interact is called again then finish the dialogue instantly
        {
            StopAllCoroutines();
            dialogueController.SetDialogueText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }

        //clear choices
        dialogueController.ClearChoices();

        //end dialogue if set as true
        if (dialogueData.endDialogueLines.Length > dialogueIndex && dialogueData.endDialogueLines[dialogueIndex])
        {
            EndDialogue();
            return;
        }

        //check if this dialogue has choices then display
        foreach (DialogueChoice dialogueChoice in dialogueData.choices)
        {
            if (dialogueChoice.dialogueIndex == dialogueIndex) // if there are choices available at the current index then
            {
                //display choices
                DisplayChoices(dialogueChoice);
                return;
            }
        }


        if (dialogueData.autoProgressLines.Length > ++dialogueIndex) // move to next line if there is one
        {
            ShowCurrentLine();
        }
        else
        {
            EndDialogue();
        }
    }

    void DisplayChoices(DialogueChoice choice)
    {
        for (int i = 0; i < choice.choices.Length; i++)
        {
            int nextIndex = choice.nextDialogueIndex[i];
            string choiceText = choice.choices[i];

            if (dialogueData.itemToGive != null && dialogueData.itemToGive.canBePicked && choiceText == "Yes")
            {
                dialogueController.CreateChoiceButton("Yes", () =>
                {
                    if(dialogueData.itemToGive.type == "Key")
                    {
                        InventoryManager.hasKey = true;
                    }
                    InventoryManager.instance.SetItem(dialogueData.itemToGive);
                    obtainedSFX.Play();
                    gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.transform.GetChild(0).GetComponent<Light2D>().enabled = false;
                    Invoke("DestroyObject" , 3f);
                    ChooseOption(nextIndex);
                });
            }
            else
            {
                dialogueController.CreateChoiceButton(choice.choices[i], () => ChooseOption(nextIndex));
            }
        }
    }

    void ChooseOption(int nextIndex)
    {
        dialogueIndex = nextIndex;
        dialogueController.ClearChoices();
        ShowCurrentLine();
    }

    void ShowCurrentLine()
    {
        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }

    public void EndDialogue()  // end the dialogue
    {
        StopAllCoroutines();
        dialogueController.ShowDialogueUI(false);
        PlayerMovement.isPlayerWalkable = true;
        dialogueController.SetDialogueText("");
        isDialogueActive = false;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }


}

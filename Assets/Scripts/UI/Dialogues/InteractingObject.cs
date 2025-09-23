using System.Collections;
using TMPro;
using UnityEngine;

public class InteractingObject : MonoBehaviour
{
    public InteractableDialogue dialogueData;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

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
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);

        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach (char letter in dialogueData.dialogueLines[dialogueIndex]) 
        {
            //show the dialogue in animation
            dialogueText.text += letter;
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
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (dialogueData.autoProgressLines.Length > ++dialogueIndex) // move to next line if there is one
        {
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }

    public void EndDialogue()  // end the dialogue
    {
        StopAllCoroutines();
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        isDialogueActive = false;
    }


}

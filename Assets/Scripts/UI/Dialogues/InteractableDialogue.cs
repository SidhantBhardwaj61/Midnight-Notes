using UnityEngine;

[CreateAssetMenu(fileName = "new interacting dialogue", menuName = "Interacting dialogue")]
public class InteractableDialogue : ScriptableObject
{
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public bool[] endDialogueLines; // set where the dialogue should end
    public float typingSpeed;
    public float autoProgressDelay = 1.5f;

    public DialogueChoice[] choices;
    public ItemInformation itemToGive;
}

[System.Serializable]
public class DialogueChoice
{
    public int dialogueIndex; // index at which choice appears
    public string[] choices; // what are the choices
    public int[] nextDialogueIndex; // what index does the choice lead to
}

using UnityEngine;

[CreateAssetMenu(fileName = "new interacting dialogue" , menuName = "Interacting dialogue")]
public class InteractableDialogue : ScriptableObject
{
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float typingSpeed;
    public AudioClip dialogueSound;
    public float autoProgressDelay = 1.5f;
}

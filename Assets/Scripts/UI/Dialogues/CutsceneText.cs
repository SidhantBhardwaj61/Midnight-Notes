using System.Collections;
using UnityEngine;

public class CutsceneText : MonoBehaviour
{
    [SerializeField] string text;
    [SerializeField] TMPro.TMP_Text dialogue;
    [SerializeField] float textAnimTime = 0.05f;

    void OnEnable()
    {
        dialogue.text = "";              // Clear text first
        StartCoroutine(TypeText());      // Start animation
    }

    IEnumerator TypeText()
    {
        foreach (char letter in text)
        {
            dialogue.text += letter;     // Add one letter at a time
            yield return new WaitForSeconds(textAnimTime); // Delay
        }
    }
}

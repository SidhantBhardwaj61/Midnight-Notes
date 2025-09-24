using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public static DialogueController instance { get; private set; } //get the instance anywhere but set private
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public Transform choicePanel;
    public GameObject choiceButtonPrefab;

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void ShowDialogueUI(bool show)
    {
        dialoguePanel.SetActive(show);
    }

    public void SetDialogueText(string text)
    {
        dialogueText.text = text;
    }

    public void ClearChoices()
    {
        foreach (Transform child in choicePanel) Destroy(child.gameObject);
    }

    public void CreateChoiceButton(string choiceText, UnityEngine.Events.UnityAction onClick)
    {
        GameObject choiceButton = Instantiate(choiceButtonPrefab, choicePanel);
        choiceButton.GetComponentInChildren<TMP_Text>().text = dialogueText.text;
        choiceButton.GetComponentInChildren<Button>().onClick.AddListener(onClick);
    }
}

using System;
using UnityEngine;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text enteredPassword;
    [SerializeField] string correctPassword;

    void OnEnable()
    {
        enteredPassword.text = "";
    }

    // the number which is entered on pressing a button
    public void SetNumber(int num)
    {
        if (enteredPassword.text.Length <= 3)
        {
            enteredPassword.text += num.ToString();
        }
    }

    // check the entered password
    public void Enter()
    {
        if (enteredPassword.text == correctPassword)
        {
            enteredPassword.text = "CORRECT!";
            Invoke(nameof(Close) , 1f);
        }
        else
        {
            enteredPassword.text = "INCORRECT!";
            Invoke(nameof(Clear), 1f);
        }
    }

    public void Backspace()
    {
        if (enteredPassword.text.Length > 0)
        {
            enteredPassword.text = enteredPassword.text.Substring(0, enteredPassword.text.Length - 1);
        }
    }

    public void Clear()
    {
        enteredPassword.text = "";
    }
    
    public void Close()
    {
        this.gameObject.SetActive(false);
    }
}

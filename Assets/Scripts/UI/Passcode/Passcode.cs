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
        if (enteredPassword.text.Length <= 4)
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
        }
        else
        {
            enteredPassword.text = "INCORRECT!";
        }
    }
}

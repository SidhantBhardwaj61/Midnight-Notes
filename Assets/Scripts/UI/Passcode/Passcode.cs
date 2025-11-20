using System;
using UnityEngine;
using UnityEngine.UI;

public class Passcode : MonoBehaviour
{
    [SerializeField] AudioSource correctSFX;
    [SerializeField] AudioSource wrongSFX;
    [SerializeField] AudioSource clickSFX;
    [SerializeField] AudioSource enableSFX;
    [SerializeField] private TMPro.TMP_Text enteredPassword;
    [SerializeField] string correctPassword;

    void OnEnable()
    {
        enableSFX.Play();
        enteredPassword.text = "";
    }

    // the number which is entered on pressing a button
    public void SetNumber(int num)
    {
        if (enteredPassword.text.Length <= 3)
        {
            enteredPassword.text += num.ToString();
            clickSFX.Play();
        }
        
    }

    // check the entered password
    public void Enter()
    {
        if (enteredPassword.text == correctPassword)
        {
            enteredPassword.text = "CORRECT!";
            correctSFX.Play();
            Invoke(nameof(Close) , 1f);
        }
        else
        {
            enteredPassword.text = "INCORRECT!";
            wrongSFX.Play();
            Invoke(nameof(Clear), 1f);
        }
    }

    public void Backspace()
    {
        if (enteredPassword.text.Length > 0)
        {
            enteredPassword.text = enteredPassword.text.Substring(0, enteredPassword.text.Length - 1);
        }
        clickSFX.Play();
    }

    public void Clear()
    {
        clickSFX.Play();
        enteredPassword.text = "";
    }
    
    public void Close()
    {
        clickSFX.Play();
        this.gameObject.SetActive(false);
        if(PlayerMovement.isPlayerWalkable == false)
        {
            PlayerMovement.isPlayerWalkable = true;
        }
    }
}

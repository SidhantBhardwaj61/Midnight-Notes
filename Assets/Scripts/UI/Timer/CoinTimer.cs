using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinTimer : MonoBehaviour
{
    float timerSeconds = 30f; //time in seconds

    [SerializeField] TMP_Text timerText;
    Slider countdownTimer;
    public bool timerActive = false;
    

    void OnEnable()
    {
        timerActive = true;
        countdownTimer = GetComponent<Slider>();
        countdownTimer.maxValue = timerSeconds;
        countdownTimer.value = timerSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        countdownTimer.value -= Time.deltaTime; //decreases by 1 for every sec
        timerText.text = Mathf.CeilToInt(countdownTimer.value).ToString(); //time remains in int

        //if the timer ended
        if (countdownTimer.value <= 0)
        {
            timerActive = false;
            gameObject.SetActive(false);

            //reset the timer settings
            countdownTimer.maxValue = timerSeconds;
            countdownTimer.value = timerSeconds;
        }

    }
}

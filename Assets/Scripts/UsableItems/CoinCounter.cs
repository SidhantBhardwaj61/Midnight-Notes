using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    TMPro.TMP_Text numberString;

    void OnEnable()
    {
        numberString = GetComponent<TMPro.TMP_Text>();
    }

    void Update()
    {
        numberString.text = CoinSpawner.numberOfCoins.ToString();
    }
}

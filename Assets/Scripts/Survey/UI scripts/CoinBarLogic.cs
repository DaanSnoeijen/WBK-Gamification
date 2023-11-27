using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinBarLogic : MonoBehaviour
{
    [Header("Image to edit filler from")]
    [SerializeField] Image CoinBar;
    [SerializeField] TextMeshProUGUI Percentage;
    [SerializeField] TextMeshProUGUI PrizeText;

    float oldValue;
    float stepValue;
    float fractionValue = 20f;

    int loopRate = 80;

    public void SetProgressBar(float newValue) { StartCoroutine(IProgressBarAnim(newValue)); }

    IEnumerator IProgressBarAnim(float newValue)
    {
        float coinsLeft;

        for (int i = 0; i < loopRate; i++)
        {
            oldValue = CoinBar.fillAmount;

            stepValue = (newValue / 100f - oldValue) / fractionValue;
            CoinBar.fillAmount += stepValue;

            yield return new WaitForSeconds(1f / loopRate);
        }

        CoinBar.fillAmount = newValue / 100f;
        Percentage.text = newValue.ToString() + "%";
        coinsLeft = (100f - newValue) / 100f * 500;
        PrizeText.text = "Nog " + Mathf.Round(coinsLeft) + " munten te gaan voor een 5 euro Bol.com tegoed!";
    }
}

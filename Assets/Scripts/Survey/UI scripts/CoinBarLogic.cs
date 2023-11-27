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
    float percent;
    float coinsLeft = 500f;
    float fractionValue = 20f;

    int loopRate = 80;

    public void SetProgressBar(float newValue) { StartCoroutine(IProgressBarAnim(newValue)); }

    IEnumerator IProgressBarAnim(float newValue)
    {
        for (int i = 0; i < loopRate; i++)
        {
            oldValue = CoinBar.fillAmount;

            stepValue = (newValue / 100f - oldValue) / fractionValue;
            CoinBar.fillAmount += stepValue;

            percent += (newValue - oldValue * 100f) / fractionValue;
            Percentage.text = Mathf.Round(percent) + "%";

            coinsLeft -= 1;
            PrizeText.text = "Nog " + Mathf.Round(coinsLeft) + " munten te gaan voor een 5 euro Bol.com tegoed!";

            yield return new WaitForSeconds(1f / loopRate);
        }

        CoinBar.fillAmount = newValue / 100f;
        Percentage.text = newValue.ToString() + "%";
        coinsLeft = (100f - newValue) / 100f * 500;
        PrizeText.text = "Nog " + Mathf.Round(coinsLeft) + " munten te gaan voor een 5 euro Bol.com tegoed!";
    }
}

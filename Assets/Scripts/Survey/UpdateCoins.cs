using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpdateCoins : MonoBehaviour
{
    [Header("Coin pop up animator")]
    [SerializeField] Animator PopupAnimator;

    [Header("Coin pop up object")]
    [SerializeField] GameObject PopupObject;
    [SerializeField] TextMeshProUGUI CoinText;

    int coins = 0;

    public void ShowNewCoins(int newCoins) { StartCoroutine(IShowNewCoins(newCoins)); }

    IEnumerator IShowNewCoins(int newCoins)
    {
        PopupObject.SetActive(true);
        PopupAnimator.SetTrigger("Show");

        yield return new WaitForSeconds(1.5f);

        for (int i = 0; i < newCoins; i++)
        {
            coins++;
            CoinText.text = coins.ToString();

            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(2f);

        PopupAnimator.SetTrigger("Hide");
        yield return new WaitForSeconds(1f);

        PopupObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSetter : MonoBehaviour
{
    [Header("Image to edit filler from")]
    [SerializeField] Image ProgressBar;

    float oldValue;
    float stepValue;
    float fractionValue = 20f;

    int loopRate = 80;

    public void SetProgressBar(float newValue) { StartCoroutine(IProgressBarAnim(newValue)); }

    IEnumerator IProgressBarAnim(float newValue)
    {
        for (int i = 0; i < loopRate; i++)
        {
            oldValue = ProgressBar.fillAmount;

            stepValue = (newValue - oldValue) / fractionValue;
            ProgressBar.fillAmount += stepValue;

            yield return new WaitForSeconds(1f / loopRate);
        }

        ProgressBar.fillAmount = newValue;
    }
}

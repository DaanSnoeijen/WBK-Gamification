using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSetter : MonoBehaviour
{
    [Header("Image to edit filler from")]
    [SerializeField] Image ProgressBar;
    [SerializeField] Image ProgressBarBack;

    [Header("Questions left text")]
    [SerializeField] TextMeshProUGUI QuestionsLeft;

    float oldValue;
    float stepValue;
    float fractionValue = 20f;

    int loopRate = 80;

    int qLeft = 0;
    int qTotal = 0;

    public void SetProgressBar(float newValue) { StartCoroutine(IProgressBarAnim(newValue)); }

    public void SetQuestionsTotal(int questionsTotal) 
    { 
        qTotal = questionsTotal;
        QuestionsLeft.text = "0/" + qTotal;
    }

    public void SetQuestionsLeft(int questionsLeft) 
    { 
        qLeft = questionsLeft;
        QuestionsLeft.text = qLeft + "/" + qTotal;
    }

    IEnumerator IProgressBarAnim(float newValue)
    {
        for (int i = 0; i < loopRate; i++)
        {
            oldValue = ProgressBar.fillAmount;

            stepValue = (newValue - oldValue) / fractionValue;
            ProgressBar.fillAmount += stepValue;
            ProgressBarBack.fillAmount += stepValue;

            yield return new WaitForSeconds(1f / loopRate);
        }

        ProgressBar.fillAmount = newValue;
        ProgressBarBack.fillAmount = newValue;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnboardingManager : MonoBehaviour
{
    [Header("Onboarding screens")]
    [SerializeField] List<string> DescriptionItems;

    [Header("Progressbar settings")]
    [SerializeField] GameObject MainDot;
    [SerializeField] TextMeshProUGUI Description;
    [SerializeField] Animator FocusAnimator;
    [SerializeField] Animator DotAnimator;
    [SerializeField] Animator ButtonLAnimator;
    [SerializeField] Animator ButtonRAnimator;

    [Header("Close onboarding items")]
    [SerializeField] Animator PanelAnimator;
    [SerializeField] GameObject Screens;

    int dotStep = 0;

    public void ChangeDot(bool right)
    {
        if (right && dotStep < DescriptionItems.Count - 1)
        {
            dotStep++;
            FocusAnimator.SetTrigger("Next");
        }
        else if (!right && dotStep > 0)
        {
            dotStep--;
            FocusAnimator.SetTrigger("Previous");
        }
        else return;

        if (dotStep == 0) ButtonLAnimator.SetTrigger("Hide");
        else if (right && dotStep == 1) ButtonLAnimator.SetTrigger("Show");
        if (dotStep == DescriptionItems.Count - 1) ButtonRAnimator.SetTrigger("Hide");
        else if (!right && dotStep == DescriptionItems.Count - 2) ButtonRAnimator.SetTrigger("Show");

        StartCoroutine(IMoveMainDot(right));
        StartCoroutine(IChangeDescription());
    }

    public void CloseOnboarding()
    {
        PanelAnimator.SetTrigger("Hide");
        Screens.SetActive(false);
    }
    
    IEnumerator IMoveMainDot(bool right)
    {
        DotAnimator.SetTrigger("Move");
        PanelAnimator.SetTrigger(right ? "Next" : "Previous");

        for (int i = 0; i < 15; i++)
        {
            MainDot.GetComponent<RectTransform>().anchoredPosition += right ? Vector2.right * 2 : Vector2.left * 2;
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator IChangeDescription()
    {
        int dotChange = dotStep;
        char[] Letters = DescriptionItems[dotStep].ToCharArray();
        Description.text = "";

        foreach (var letter in Letters)
        {
            if (dotStep != dotChange) yield break;

            Description.text += letter;
            yield return new WaitForSeconds(0.03f);
        }
    }
}

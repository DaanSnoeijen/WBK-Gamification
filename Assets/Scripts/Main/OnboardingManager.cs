using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingManager : MonoBehaviour
{
    [Header("Onboarding screens")]
    [SerializeField] List<GameObject> ForeGrounds = new List<GameObject>();

    [Header("Progressbar settings")]
    [SerializeField] GameObject MainDot;
    [SerializeField] Animator DotAnimator;
    [SerializeField] Animator ButtonLAnimator;
    [SerializeField] Animator ButtonRAnimator;

    [Header("Close onboarding items")]
    [SerializeField] Animator PanelAnimator;
    [SerializeField] GameObject Screens;

    int dotStep = 0;

    public void ChangeDot(bool right)
    {
        if (right && dotStep < ForeGrounds.Count - 1) dotStep++;
        else if (!right && dotStep > 0) dotStep--;
        else return;

        if (dotStep == 0) ButtonLAnimator.SetTrigger("Hide");
        else if (right && dotStep == 1) ButtonLAnimator.SetTrigger("Show");
        if (dotStep == ForeGrounds.Count - 1) ButtonRAnimator.SetTrigger("Hide");
        else if (!right && dotStep == ForeGrounds.Count - 2) ButtonRAnimator.SetTrigger("Show");

        StartCoroutine(IMoveMainDot(right));
    }

    public void CloseOnboarding()
    {
        PanelAnimator.SetTrigger("Hide");
        Screens.SetActive(false);
    }
    
    IEnumerator IMoveMainDot(bool right)
    {
        DotAnimator.SetTrigger("Move");

        for (int i = 0; i < 15; i++)
        {
            MainDot.GetComponent<RectTransform>().anchoredPosition += right ? Vector2.right * 2 : Vector2.left * 2;
            yield return new WaitForEndOfFrame();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnboardingManager : MonoBehaviour
{
    [SerializeField] List<GameObject> ForeGrounds = new List<GameObject>();

    [Header("Progressbar settings")]
    [SerializeField] GameObject MainDot;
    [SerializeField] Animator DotAnimator;

    int dotStep = 0;

    public void ChangeDot(bool right)
    {
        if (right && dotStep < ForeGrounds.Count - 1) dotStep++;
        else if (!right && dotStep > 0) dotStep--;
        else return;

        StartCoroutine(IMoveMainDot(right));
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

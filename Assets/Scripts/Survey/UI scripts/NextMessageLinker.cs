using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMessageLinker : MonoBehaviour
{
    [SerializeField] SurveyManager SurveyManager;
    [SerializeField] RectTransform ViewportTransform;

    public void NextMessage() { SurveyManager.NextMessage(); }

    public RectTransform ReturnTransform() { return ViewportTransform; }
}

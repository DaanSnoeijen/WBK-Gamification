using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSliderContentLinker : MonoBehaviour
{
    [Header("To link components")]
    [SerializeField] SurveyManager SurveyManager;

    int maxValue;

    public int GetMaxValue() { return maxValue; }

    public void SetMaxValue(int maxValue) { this.maxValue = maxValue; }

    public void NextMessage() { SurveyManager.NextMessage(); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSliderContentLinker : MonoBehaviour
{
    [Header("To link components")]
    [SerializeField] GameObject Content;
    [SerializeField] SurveyManager SurveyManager;

    int maxValue;

    public int GetMaxValue() { return maxValue; }

    public void SetMaxValue(int maxValue) { this.maxValue = maxValue; }

    public Vector2 GetRotationSliderPoint()
    {
        return new Vector2(220, Content.transform.position.y * 60f + 35);
    }

    public void NextMessage() { SurveyManager.NextMessage(); }
}

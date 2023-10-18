using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftNextMessage : MonoBehaviour
{
    [SerializeField] SurveyManager SurveyManager;

    public void NextMessage() { SurveyManager.NextMessage(); }
}

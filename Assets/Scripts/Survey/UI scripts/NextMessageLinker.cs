using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextMessageLinker : MonoBehaviour
{
    [SerializeField] SurveyManager SurveyManager;

    public void NextMessage() { SurveyManager.NextMessage(); }
}

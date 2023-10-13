using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SurveyChecker : MonoBehaviour
{
    List<TMP_InputField> _InputFields = new List<TMP_InputField>();

    public void AddUserText(TMP_InputField field) { _InputFields.Add(field); }

    public bool CheckAnswers()
    {
        foreach (TMP_InputField item in _InputFields) if (item.text == "") return false;
        return true;
    }
}

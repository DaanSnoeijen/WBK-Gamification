using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishButtonLink : MonoBehaviour
{
    FinishButtonLogic FinishButtonLogic;

    private void Start()
    {
        FinishButtonLogic = GetComponentInParent<FinishButtonLogic>();
    }

    public void ShowFinishScreen(bool show) { FinishButtonLogic.ShowFinishScreen(show); }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    [Header("Animations for menu")]
    [SerializeField] Animator PanelAnimator;

    [Header("Back panel")]
    [SerializeField] GameObject BackPanel;

    bool show;

    public void ShowCloseScreen() { StartCoroutine(IShowCloseScreen()); }

    IEnumerator IShowCloseScreen()
    {
        show = !show;
        PanelAnimator.SetTrigger(show.ToString());

        if (!show) yield return new WaitForSeconds(1f);
        BackPanel.SetActive(show);
    }
}

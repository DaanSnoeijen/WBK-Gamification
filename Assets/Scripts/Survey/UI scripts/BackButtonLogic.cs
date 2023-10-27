using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonLogic : MonoBehaviour
{
    [Header("Animations for closing")]
    [SerializeField] Animator BackAnimator;
    [SerializeField] Animator PanelAnimator;

    [Header("Enable panel")]
    [SerializeField] GameObject FocusBackpanel;
    [SerializeField] GameObject ExitPanel;
    [SerializeField] GameObject CloseBack;

    public void ShowCloseScreen(bool show) { StartCoroutine(IShowCloseScreen(show)); }

    IEnumerator IShowCloseScreen(bool show)
    {
        if (show)
        {
            FocusBackpanel.SetActive(true);
            ExitPanel.SetActive(true);

            BackAnimator.SetTrigger("Close");
            PanelAnimator.SetTrigger("Show");

            yield return new WaitForSeconds(1f);
            CloseBack.SetActive(true);
        }
        else
        {
            CloseBack.SetActive(false);
            BackAnimator.SetTrigger("Open");
            PanelAnimator.SetTrigger("Hide");
            yield return new WaitForSeconds(1f);

            FocusBackpanel.SetActive(false);
            ExitPanel.SetActive(false);
        }
    }
}

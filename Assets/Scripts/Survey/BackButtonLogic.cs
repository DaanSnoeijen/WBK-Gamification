using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonLogic : MonoBehaviour
{
    [Header("Animations for closing")]
    [SerializeField] Animator BackAnimator;
    [SerializeField] Animator PanelAnimator;

    [Header("Enable panel")]
    [SerializeField] GameObject BackPanel;
    [SerializeField] GameObject ExitPanel;

    public void ShowCloseScreen(bool show) { StartCoroutine(IShowCloseScreen(show)); }

    IEnumerator IShowCloseScreen(bool show)
    {
        if (show)
        {
            BackPanel.SetActive(true);
            ExitPanel.SetActive(true);

            BackAnimator.SetTrigger("Close");
            PanelAnimator.SetTrigger("Show");
        }
        else
        {
            BackAnimator.SetTrigger("Open");
            PanelAnimator.SetTrigger("Hide");
            yield return new WaitForSeconds(1f);

            BackPanel.SetActive(false);
            ExitPanel.SetActive(false);
        }
    }
}

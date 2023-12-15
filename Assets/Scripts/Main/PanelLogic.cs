using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLogic : MonoBehaviour
{
    [Header("Animations for closing")]
    [SerializeField] Animator PanelAnimator;
    [SerializeField] Animator BackAnimator;

    [Header("Enable panel")]
    [SerializeField] GameObject BackButton;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject BackPanel;

    public void ShowCloseScreen(bool show) { StartCoroutine(IShowCloseScreen(show)); }

    IEnumerator IShowCloseScreen(bool show)
    {
        if (show)
        {
            BackPanel.SetActive(true);
            Panel.SetActive(true);
            PanelAnimator.SetTrigger("Show");
            BackAnimator.SetTrigger("Close");

            yield return new WaitForSeconds(1f);
            BackButton.SetActive(true);
        }
        else
        {
            PanelAnimator.SetTrigger("Hide");
            BackAnimator.SetTrigger("Open");
            BackButton.SetActive(false);
            yield return new WaitForSeconds(1f);

            BackPanel.SetActive(false);
            Panel.SetActive(false);
        }
    }
}

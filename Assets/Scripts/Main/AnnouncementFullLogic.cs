using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementFullLogic : MonoBehaviour
{
    [Header("Visibility game objects")]
    [SerializeField] GameObject AnnouncementFull;
    [SerializeField] GameObject Messages;

    [Header("Game object animators")]
    [SerializeField] Animator AnnouncementFullAnimator;
    [SerializeField] Animator MessagesAnimator;

    public void ShowFull(bool show) { StartCoroutine(IShowFull(show)); }

    IEnumerator IShowFull(bool show)
    {
        if (show)
        {
            AnnouncementFull.SetActive(true);
            AnnouncementFullAnimator.SetTrigger("Show");
            MessagesAnimator.SetTrigger("Hide");

            yield return new WaitForSeconds(1f);
            Messages.SetActive(false);
        }
        else
        {
            AnnouncementFull.SetActive(false);
        }
    }
}

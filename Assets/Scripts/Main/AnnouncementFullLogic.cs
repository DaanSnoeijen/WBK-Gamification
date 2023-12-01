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
    [SerializeField] Animator SwitchAnimator;

    [Header("Animation components")]
    [SerializeField] Animator SwipeAnimator;
    [SerializeField] Animator LikeSwipeAnimator;

    public void Like(bool like)
    {
        if (like)
        {
            SwipeAnimator.SetTrigger("Like");
            LikeSwipeAnimator.SetTrigger("Like");
        }
        else
        {
            SwipeAnimator.SetTrigger("Dislike");
            LikeSwipeAnimator.SetTrigger("Dislike");
        }
    }

    public void ShowFull(bool show) { StartCoroutine(IShowFull(show)); }

    IEnumerator IShowFull(bool show)
    {
        if (show)
        {
            AnnouncementFull.SetActive(true);
            AnnouncementFullAnimator.SetTrigger("Show");
            MessagesAnimator.SetTrigger("Hide");
            SwitchAnimator.SetTrigger("Hide");

            yield return new WaitForSeconds(1f);
            Messages.SetActive(false);
        }
        else
        {
            Messages.SetActive(true);
            AnnouncementFullAnimator.SetTrigger("Hide");
            MessagesAnimator.SetTrigger("Show");
            SwitchAnimator.SetTrigger("Show");

            yield return new WaitForSeconds(1f);
            AnnouncementFull.SetActive(false);
        }
    }
}

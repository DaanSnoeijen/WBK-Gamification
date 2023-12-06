using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerAnnouncementLogic : MonoBehaviour
{
    [SerializeField] Animator MarkerAnnouncementAnimator;
    [SerializeField] Animator ListAnnouncementAnimator;

    bool mShow;
    bool lShow;

    public void ShowMAnnouncement()
    {
        mShow = !mShow;

        if (mShow) MarkerAnnouncementAnimator.SetTrigger("Show");
        else MarkerAnnouncementAnimator.SetTrigger("Hide");
    }

    public void ShowLAnnouncements()
    {
        lShow = !lShow;

        if (lShow) MarkerAnnouncementAnimator.SetTrigger("Show");
        else MarkerAnnouncementAnimator.SetTrigger("Hide");
    }
}

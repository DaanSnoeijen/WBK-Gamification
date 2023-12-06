using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerAnnouncementLogic : MonoBehaviour
{
    [SerializeField] Animator MarkerAnnouncementAnimator;

    bool show;

    public void ShowMAnnouncement()
    {
        show = !show;

        if (show) MarkerAnnouncementAnimator.SetTrigger("Show");
        else MarkerAnnouncementAnimator.SetTrigger("Hide");
    }
}

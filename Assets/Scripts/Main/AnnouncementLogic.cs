using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementLogic : MonoBehaviour
{
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
}

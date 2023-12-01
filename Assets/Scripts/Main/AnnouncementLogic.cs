using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnnouncementLogic : MonoBehaviour
{
    [SerializeField] Animator SwipeAnimator;
    [SerializeField] Animator LikeSwipeAnimator;

    [SerializeField] GameObject LikeFront;
    [SerializeField] GameObject DislikeFront;

    public void Like(bool like)
    {
        if (like)
        {
            SwipeAnimator.SetTrigger("Like");
            LikeSwipeAnimator.SetTrigger("Like");
            //LikeFront.SetActive(false);
            //DislikeFront.SetActive(true);
        }
        else
        {
            SwipeAnimator.SetTrigger("Dislike");
            LikeSwipeAnimator.SetTrigger("Dislike");
            //LikeFront.SetActive(true);
            //DislikeFront.SetActive(false);
        }
    }
}

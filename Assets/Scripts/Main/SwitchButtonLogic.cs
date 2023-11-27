using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButtonLogic : MonoBehaviour
{
    [Header("Switch menu items")]
    [SerializeField] Animator SwitchAnimator;
    [SerializeField] Animator BackAnimator;

    bool currentLeft = true;

    public void Switch(bool left)
    {
        if (left && !currentLeft)
        {
            SwitchAnimator.SetTrigger("Left");
            BackAnimator.SetTrigger("Hide");
            currentLeft = true;
        }
        else if (!left && currentLeft)
        {
            SwitchAnimator.SetTrigger("Right");
            BackAnimator.SetTrigger("Show");
            currentLeft = false;
        }
    }
}

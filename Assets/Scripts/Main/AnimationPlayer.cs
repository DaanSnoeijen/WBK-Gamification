using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [Header("Animation to play")]
    [SerializeField] Animator Animator;

    bool trigger;

    public void PlayTrigger(string triggerName) { Animator.SetTrigger(triggerName); }

    public void ToggleTrigger()
    {
        trigger = !trigger;
        Animator.SetTrigger(trigger.ToString());
    }
}

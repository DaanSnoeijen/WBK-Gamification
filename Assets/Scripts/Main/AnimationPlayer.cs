using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [Header("Animation to play")]
    [SerializeField] Animator Animator;

    public void PlayAnim(string triggerName) { Animator.SetTrigger(triggerName); }
}

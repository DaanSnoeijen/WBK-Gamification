using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{
    [Header("Stars")]
    [SerializeField] Image StarLeft;
    [SerializeField] Image StarMiddle;
    [SerializeField] Image StarRight;

    [Header("Particle effects")]
    [SerializeField] ParticleSystem StarFXLeft;
    [SerializeField] ParticleSystem StarFXMiddle;
    [SerializeField] ParticleSystem StarFXRight;

    [Header("Star animators")]
    [SerializeField] Animator StarAnimatorLeft;
    [SerializeField] Animator StarAnimatorMiddle;
    [SerializeField] Animator StarAnimatorRight;

    public void StartAnimation() { StartCoroutine(IStarAnimation()); }

    IEnumerator IStarAnimation()
    {
        StarAnimatorLeft.SetTrigger("Show");
        yield return new WaitForSeconds(0.5f);
        StarLeft.color = new Color(1f, 1f, 1f, 1f);
        StarFXLeft.Play();

        StarAnimatorMiddle.SetTrigger("Show");
        yield return new WaitForSeconds(0.5f);
        StarMiddle.color = new Color(1f, 1f, 1f, 1f);
        StarFXMiddle.Play();

        StarAnimatorRight.SetTrigger("Show");
        yield return new WaitForSeconds(0.5f);
        StarRight.color = new Color(1f, 1f, 1f, 1f);
        StarFXRight.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdeaSelection : MonoBehaviour
{
    [Header("Idea animation")]
    [SerializeField] Animator IdeaAnimator;
    [SerializeField] Animator PositionSelectionAnimator;
    [SerializeField] ParticleSystem SmokeEffect;
    [SerializeField] Button MapButton;

    [Header("Idea object parenting")]
    [SerializeField] RectTransform IdeaObjectRect;
    [SerializeField] Transform IdeaObject;
    [SerializeField] Transform NewParent;
    [SerializeField] Transform OldParent;

    public void SelectIdea() { StartCoroutine(ISelectIdea()); }

    IEnumerator ISelectIdea()
    {
        MapButton.interactable = true;

        Vector2 oldPosition = IdeaObjectRect.anchoredPosition;
        IdeaObject.SetParent(NewParent);
        IdeaAnimator.SetTrigger("Select");

        yield return new WaitForSeconds(0.7f);
        SmokeEffect.Play();
        PositionSelectionAnimator.SetTrigger("Show");

        yield return new WaitForSeconds(3f);
        IdeaObject.SetParent(OldParent);
        IdeaObjectRect.anchoredPosition = oldPosition;
    }
}

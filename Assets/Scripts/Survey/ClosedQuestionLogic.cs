using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedQuestionLogic : MonoBehaviour
{
    [Header("Selection animations")]
    [SerializeField] Animator AnswerAnimator;
    [SerializeField] Animator MessageBackAnimator;

    [Header("Message back panel")]
    [SerializeField] RectTransform MessageBackSize;
    [SerializeField] RectTransform ThisSize;

    bool selected;

    private void Start()
    {
        MessageBackSize.sizeDelta = new Vector2(255, ThisSize.sizeDelta.y / 2f + 5);
        MessageBackSize.position = new Vector3(MessageBackSize.position.x,
            MessageBackSize.position.y - (ThisSize.sizeDelta.y - 53.52f) / 4850f, 
            MessageBackSize.position.z);
    }

    public void ChangeSelected()
    {
        selected = !selected;

        if (selected)
        {
            AnswerAnimator.SetTrigger("On");
            MessageBackAnimator.SetTrigger("On");
        }
        else
        {
            AnswerAnimator.SetTrigger("Off");
            MessageBackAnimator.SetTrigger("Off");
        }
    }
}

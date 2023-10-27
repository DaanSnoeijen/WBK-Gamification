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

    [Header("Checkbox or radiobox")]
    [SerializeField] GameObject Checkbox;
    [SerializeField] GameObject Radiobox;

    List<ClosedQuestionLogic> _otherAnswers;

    bool selected;
    bool radio;
    bool canNextMessage = true;

    private void Start()
    {
        MessageBackSize.sizeDelta = new Vector2(255, ThisSize.sizeDelta.y / 2f + 5);
        MessageBackSize.position = new Vector3(MessageBackSize.position.x,
            MessageBackSize.position.y - (ThisSize.sizeDelta.y - 53.52f) / 4850f, 
            MessageBackSize.position.z);
    }

    public void SetAnswerGroup(List<ClosedQuestionLogic> otherAnswers) { _otherAnswers = otherAnswers; }

    public void SetType(bool isRadio)
    {
        radio = isRadio;
        if (isRadio) Radiobox.SetActive(true);
        else Checkbox.SetActive(true);
    }

    public void ChangeSelected()
    {
        selected = !selected;

        if (selected)
        {
            if (radio)
            {
                if (canNextMessage) GetComponentInParent<NextMessageLinker>().NextMessage();

                foreach (var item in _otherAnswers)
                {
                    item.canNextMessage = false;
                    if (item != this && item.selected) item.ChangeSelected();
                }
            }

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

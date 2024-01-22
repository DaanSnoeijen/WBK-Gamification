using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMapLogic : MonoBehaviour
{
    [Header("Object with point image on map")]
    [SerializeField] RectTransform Pointer;

    [Header("Move instructions for map")]
    [SerializeField] GameObject Instructions;
    [SerializeField] Animator MapAnimator;
    [SerializeField] Animator ButtonAnimator;
    [SerializeField] Animator InstructionAnimator;

    bool canNextMessage = true;

    public void SetInstructions(bool show) 
    {
        Instructions.SetActive(show); 
    }

    public void SetMapSize(bool big) { MapAnimator.SetTrigger(big.ToString()); }

    public void SetPointer()
    {
        Vector2 position = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        position.y += 446;
        position.x -= 567;
        Pointer.anchoredPosition = position;

        ButtonAnimator.SetTrigger("Show");
    }

    public void NextMessage() { StartCoroutine(INextMessage()); }

    IEnumerator INextMessage()
    {
        ButtonAnimator.SetTrigger("Hide");
        SetMapSize(false);

        if (canNextMessage)
        {
            GetComponentInParent<NextMessageLinker>().NextMessage();
            canNextMessage = false;
        }

        yield return new WaitForSeconds(1f);
        SetInstructions(true);
        InstructionAnimator.SetTrigger("Show");
    }
}

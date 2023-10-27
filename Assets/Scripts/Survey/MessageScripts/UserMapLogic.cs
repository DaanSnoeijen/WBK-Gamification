using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UserMapLogic : MonoBehaviour
{
    [Header("Object with point image on map")]
    [SerializeField] RectTransform Pointer;

    [Header("Move instructions for map")]
    [SerializeField] GameObject Instructions;

    bool canNextMessage = true;

    public void SetInstructions(bool show) { Instructions.SetActive(show); }

    public void SetPointer()
    {
        Vector2 position = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        position.y += 457;
        position.x -= 567;
        Pointer.anchoredPosition = position;

        if (canNextMessage)
        {
            GetComponentInParent<NextMessageLinker>().NextMessage();
            canNextMessage = false;
        }
    }
}

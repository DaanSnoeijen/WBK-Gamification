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

    public void SetInstructions(bool show) { Instructions.SetActive(show); }

    public void SetPointer()
    {
        Vector2 position = transform.InverseTransformPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        position.y += 550;
        position.x -= 680;
        Pointer.anchoredPosition = position;

        GetComponentInParent<NextMessageLinker>().NextMessage();
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputAutoselect : MonoBehaviour
{
    [Header("Input field to autoselect")]
    [SerializeField] TMP_InputField Field;

    RectTransform rectTransform;

    Vector3 NormalPos;
    Vector3 UpPos;

    void Start()
    {
        rectTransform = GetComponentInParent<NextMessageLinker>().ReturnTransform();
        NormalPos = rectTransform.position;
        UpPos = rectTransform.position;
        UpPos.y += 3;

        Field.Select();
    }

    public void Select() { rectTransform.position = UpPos; }

    public void Deselect() { rectTransform.position = NormalPos; }
}

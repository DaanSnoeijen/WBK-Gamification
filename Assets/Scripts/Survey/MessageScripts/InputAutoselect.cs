using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputAutoselect : MonoBehaviour
{
    [Header("Input field to autoselect")]
    [SerializeField] TMP_InputField Field;

    void Start()
    {
        Field.Select();
    }
}

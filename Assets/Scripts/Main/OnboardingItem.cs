using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OnboardingItem
{
    [Header("Backpanels to focus object")]
    public GameObject ScreenObject;

    [Header("What will the text in the explanation be?")]
    [TextArea(3, 20)]
    public string text;

    [Header("Animations to move panel")]
    [SerializeField] Animation Animation;
}

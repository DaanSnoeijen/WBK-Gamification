using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CircleSliderLogic : MonoBehaviour
{
    [Header("Slider items that move on touch")]
    [SerializeField] GameObject HandleArea;
    [SerializeField] Slider Slider;
    [SerializeField] Animator ButtonAnimator;

    [Header("Text in slider")]
    [SerializeField] TextMeshProUGUI Text;

    CircleSliderContentLinker Linker;

    Vector2 RotationPosition;

    bool pressed;
    bool continued;

    int maxSliderValue;

    private void Start()
    {
        Linker = GetComponentInParent<CircleSliderContentLinker>();
        maxSliderValue = Linker.GetMaxValue();
    }

    private void Update()
    {
        if (pressed)
        {
            RotationPosition = Linker.GetRotationSliderPoint();
            print(RotationPosition);
            float angle = CalculateAngle(RotationPosition, Input.mousePosition);

            HandleArea.transform.eulerAngles = new Vector3(0, 0, angle);
            Slider.value = 360 - angle;

            Text.text = CalculateInputNumber(maxSliderValue);
        }
    }

    string CalculateInputNumber(int maxValue) { return Mathf.Round(maxValue * (Slider.value / 360f)).ToString(); }

    float CalculateAngle(Vector3 from, Vector3 to)
    {
        return Quaternion.FromToRotation(Vector3.up, to - from).eulerAngles.z;
    }

    private void OnMouseDown() 
    { 
        pressed = true;
        ButtonAnimator.SetTrigger("Tap");
    }

    private void OnMouseUp() 
    { 
        pressed = false;
        ButtonAnimator.SetTrigger("Release");
        if (!continued) Linker.NextMessage();
        continued = true;
    }
}

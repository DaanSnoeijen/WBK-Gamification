using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NormalSliderLogic : MonoBehaviour
{
    [Header("Slider items that move on touch")]
    [SerializeField] Slider Slider;
    [SerializeField] Animator ButtonAnimator;

    [Header("Text in slider")]
    [SerializeField] TextMeshProUGUI Text;

    CircleSliderContentLinker Linker;

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
        if (pressed) Text.text = CalculateInputNumber(maxSliderValue);
    }

    string CalculateInputNumber(int maxValue) { return Mathf.Round(maxValue * (Slider.value / 360f)).ToString(); }

    public void ButtonUp() 
    { 
        pressed = true;
        ButtonAnimator.SetTrigger("Tap");
    }

    public void ButtonDown() 
    { 
        pressed = false;
        ButtonAnimator.SetTrigger("Release");
        if (!continued) Linker.NextMessage();
        continued = true;
    }
}

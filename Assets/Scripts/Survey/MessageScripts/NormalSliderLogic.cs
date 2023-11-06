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

    bool continued;

    int maxSliderValue;

    private void Start()
    {
        Linker = GetComponentInParent<CircleSliderContentLinker>();
        maxSliderValue = Linker.GetMaxValue();
    }

    public void SetNumber() { Text.text = CalculateInputNumber(); }

    string CalculateInputNumber() { return Mathf.Round(maxSliderValue * Slider.value).ToString(); }

    public void ButtonDown()
    {
        ButtonAnimator.SetTrigger("Tap");
    }

    public void ButtonUp()
    {
        ButtonAnimator.SetTrigger("Release");
        if (!continued) Linker.NextMessage();
        continued = true;
    }
}

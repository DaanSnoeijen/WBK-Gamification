using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header("Able to send messages")]
    [SerializeField] Animator InputAnimator;

    [Header("Able to send messages")]
    [SerializeField] MessageCreator MessageCreator;

    [Header("Input field toggling")]
    [SerializeField] Image SendButtonImage;
    [SerializeField] Button SendButton;

    Color ButtonOnColor = new Color(0.99f, 0.36f, 0f);
    Color ButtonOffColor = new Color(0.29f, 0.29f, 0.29f);

    bool lastState = false;

    public void ToggleSending(bool state)
    {
        if (state != lastState)
        {
            SendButton.enabled = state;
            InputAnimator.SetTrigger(state.ToString());
            lastState = state;
        }
    }
}

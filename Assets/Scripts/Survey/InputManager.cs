using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header("Able to send messages")]
    [SerializeField] MessageCreator MessageCreator;
    [SerializeField] TMP_InputField InputField;

    [Header("Input field toggling")]
    [SerializeField] Image SendButtonImage;
    [SerializeField] Image SendButtonBackImage;
    [SerializeField] Button SendButton;

    Color ButtonOnColor = new Color(0f, 0.635f, 0.909f);
    Color ButtonOffColor = new Color(0.29f, 0.29f, 0.29f);

    Color ButtonBackOnColor = new Color(0.247f, 0.45f, 0.8f);
    Color ButtonBackOffColor = new Color(0.211f, 0.211f, 0.211f);

    public void SendUserMessage() { MessageCreator.CreateUserMessage(InputField.text); }

    public void ToggleSending(bool state)
    {
        InputField.enabled = state;
        SendButton.enabled = state;

        if (state)
        {
            SendButtonImage.color = ButtonOnColor;
            SendButtonBackImage.color = ButtonBackOnColor;
        }
        else
        {
            SendButtonImage.color = ButtonOffColor;
            SendButtonBackImage.color = ButtonBackOffColor;
        }
    }
}

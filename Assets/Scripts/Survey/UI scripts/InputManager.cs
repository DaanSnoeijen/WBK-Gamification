using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [Header("Able to send messages")]
    [SerializeField] MessageCreator MessageCreator;

    [Header("Input field toggling")]
    [SerializeField] Image SendButtonImage;
    [SerializeField] Image SendButtonBackImage;
    [SerializeField] Button SendButton;

    Color ButtonOnColor = new Color(0.99f, 0.36f, 0f);
    Color ButtonOffColor = new Color(0.29f, 0.29f, 0.29f);

    Color ButtonBackOnColor = new Color(0.83f, 0.3f, 0f);
    Color ButtonBackOffColor = new Color(0.211f, 0.211f, 0.211f);

    bool send;

    public void SetUserCanSendMessage(bool userSendMessage) { send = userSendMessage; }

    public void SendUserMessage() 
    {
        if (!send) return;
        MessageCreator.CreateUserMessage();
    }

    public void ToggleSending(bool state)
    {
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
